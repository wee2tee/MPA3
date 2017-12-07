using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DotNetDBF;
using MPA3.Misc;
using Newtonsoft.Json;
using System.Globalization;


namespace MPA3.Model
{
    public class JsonModel
    {
        public enum VAT_TYPE : int
        {
            ACQUISITION = 1,
            CASH_BASIS = 2
        }
        private List<Country> countries;

        public DocumentDetail DocumentDetail { get; set; }
        public SellerTradeParty SellerTradeParty { get; set; }
        public BuyerTradeParty BuyerTradeParty { get; set; }
        public List<LineItem> IncludedSupplyChainTradeLineItem { get; set; }
        public List<RefDocs> ReferencedDocument { get; set; }
        public ApplicableHeaderTradeSettlement ApplicableHeaderTradeSettlement { get; set; }

        public JsonModel(string data_path, string docnum)
        {
            DbfDataSet dataset = new DbfDataSet(data_path);

            IsinfoDbf isinfo = dataset.Isinfo;
            ArtrnDbf artrn = dataset.Artrn.Where(a => a.docnum == docnum).FirstOrDefault();
            StdDocumentName docName = artrn.GetDocName(dataset);
            ArmasDbf armas = dataset.Armas.Where(a => a.cuscod == artrn.cuscod).FirstOrDefault();

            ArtrnDbf refDoc = null;
            if(docName.type == StdDocumentName.TYPE._80 || docName.type == StdDocumentName.TYPE._81)
            {
                refDoc = dataset.Artrn.Where(a => a.docnum == artrn.sonum).FirstOrDefault();
            }
            else
            {
                refDoc = dataset.Artrn.Where(a => a.docnum == artrn.youref).FirstOrDefault();
            }
            
            StdDocumentName refDocName = refDoc != null ? refDoc.GetDocName(dataset) : null;

            List<StcrdDbf> stcrd = dataset.Stcrd.Where(s => s.docnum == docnum).ToList();
            List<IstabDbf> qucod = dataset.Istab.Where(i => i.tabtyp == "20" && stcrd.Select(s => s.tqucod).ToList<string>().Contains(i.typcod)).ToList();
            
            using (StreamReader rdr = File.OpenText(@"Res\Countries.json"))
            {
                countries = (List<Country>)new JsonSerializer().Deserialize(rdr, typeof(List<Country>));
            }

            // Create DocumentDetail for export to JSON
            this.DocumentDetail = new DocumentDetail
            {
                ID = artrn.docnum,
                CreationDateTime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff", CultureInfo.GetCultureInfo("en-US")),
                IssueDateTime = artrn.docdat.Value.ToString("yyyy-MM-ddTHH:mm:ss.fff", CultureInfo.GetCultureInfo("en-US")),
                SpecifiedCIDocument = "ETDA",
                Name = docName != null ? docName.Name : string.Empty,
                TypeCode = docName != null ? docName.typeCode : string.Empty,
                Purpose = docName.type == StdDocumentName.TYPE._80 || docName.type == StdDocumentName.TYPE._81 ? artrn.youref : string.Empty,
                Note = new Note
                {
                    Subject = docName.type == StdDocumentName.TYPE._80 || docName.type == StdDocumentName.TYPE._81 ? string.Empty : "หมายเหตุ",
                    Content = docName.type == StdDocumentName.TYPE._80 || docName.type == StdDocumentName.TYPE._81 ? string.Empty : artrn.youref
                }
            };

            this.SellerTradeParty = new SellerTradeParty
            {
                PostalCITradeAddress = new PostalTradeAddress
                {
                    LineOne = isinfo.addr01,
                    LineTwo = isinfo.addr02,
                    CountryID = countries.Where(c => c.Name.ToLower() == "thailand").First().Code,
                    PostcodeCode = isinfo.GetZipcod(),
                    CountrySubDivisionID = string.Empty,
                    CityID = string.Empty,
                    CitySubDivisionID = string.Empty,
                    Address = string.Empty,
                },
                Name = string.Empty,
                TaxID = isinfo.taxid,
                BranchCode = isinfo.GetOrgnumString(),
                CompleteNumber = "seller@esg.com",
                URIID = "www.esg.co.th",
                Telephone = isinfo.GetTelFax().telNum,
                Fax = isinfo.GetTelFax().faxNum,
            };

            this.BuyerTradeParty = new BuyerTradeParty
            {
                PersonName = armas.contact,
                Name = armas.prenam + " " + armas.cusnam,
                TaxID = armas.taxid,
                BranchCode = armas.GetOrgnumString(),
                CompleteNumber = "test@esg.co.th",
                URIID = "www.esg.co.th",
                Telephone = armas.GetTelFax().telNum,
                Fax = armas.GetTelFax().faxNum,
                PostalTradeAddress = new PostalTradeAddress
                {
                    CountryID = countries.Where(c => c.Name.ToLower() == "thailand").First().Code,
                    LineOne = armas.addr01,
                    LineTwo = armas.addr02 + " " + armas.addr03 + " " + armas.zipcod,
                    PostcodeCode = armas.zipcod,
                    CountrySubDivisionID = string.Empty,
                    CityID = string.Empty,
                    CitySubDivisionID = string.Empty,
                    Address = string.Empty
                }
            };

            this.IncludedSupplyChainTradeLineItem = new List<LineItem>();
            int item_count = 0;
            foreach (StcrdDbf st in stcrd)
            {
                this.IncludedSupplyChainTradeLineItem.Add(new LineItem
                {
                    LineID = (++item_count).ToString(),
                    Name = st.stkdes,
                    ChargeAmount = st.unitpr.ToString(),
                    BilledQuantity = st.trnqty.ToString(),
                    UnitCode = "",
                    UnitName = qucod.Where(q => q.typcod == st.tqucod).First().typdes,
                    ChargeIndicator = st.discamt > 0 ? "true" : "false",
                    ActualAmount = st.discamt > 0 ? st.discamt.ToString() : "",
                    NetLineTotalAmount = st.trnval.ToString(),
                    GlobalID = "",
                    ProductID = st.stkcod
                });
            }
            this.ReferencedDocument = new List<RefDocs>();
            if (refDoc != null)
            {
                this.ReferencedDocument.Add(new RefDocs
                {
                    IssuerAssignedID = refDoc.docnum,
                    IssueDateTime = refDoc.docdat.Value.ToString("yyyy-MM-ddTHH:mm:ss.fff", CultureInfo.GetCultureInfo("en-US")),
                    ReferenceTypeCode = refDocName != null ? refDocName.typeCode : string.Empty
                });
            }

            this.ApplicableHeaderTradeSettlement = new ApplicableHeaderTradeSettlement
            {
                SpecifiedTradeAllowanceCharge = new SpecifiedTradeAllowanceCharge
                {
                    ChargeIndicator = artrn.discamt > 0 ? "true" : "false",
                    ActualAmount = artrn.discamt > 0 ? artrn.discamt.ToString() : ""
                },
                InvoiceCurrencyCode = "THB",
                ApplicableTradeTax = new ApplicableTradeTax
                {
                    CalculatedRate = artrn.vatrat.ToString(), //"7.00",
                    BasisAmount = artrn.total.ToString(),
                    VatAmount = artrn.vatamt.ToString(),
                    TypeCode = "VAT"
                },
                SpecifiedTradeSettlementHeaderMonetarySummation = new SpecifiedTradeSettlementHeaderMonetarySummation
                {
                    LineTotalAmount = artrn.amount.ToString(), //string.Empty,
                    GrandTotalAmountCharactor = string.Empty,
                    TaxTotalAmount = artrn.vatamt.ToString(), //string.Empty,
                    GrandTotalAmount = (artrn.total + artrn.vatamt).ToString() //string.Empty
                }
            };
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        public CreateJsonResult WriteToFile(string destination_file_path)
        {
            try
            {
                var dest_file = destination_file_path.EndsWith(".json") ? destination_file_path : destination_file_path + ".json";
                File.WriteAllText(dest_file, this.ToString(), new UTF8Encoding(false));
                return new CreateJsonResult { createSuccess = true, message = "success" };
            }
            catch (Exception ex)
            {
                return new CreateJsonResult { createSuccess = false, message = ex.Message };
            }
        }
    }

    public class CreateJsonResult
    {
        public bool createSuccess { get; set; }
        public string message { get; set; }
    }

    public class DocumentDetail
    {
        public string ID { get; set; }
        public string CreationDateTime { get; set; }
        public string IssueDateTime { get; set; }
        public string SpecifiedCIDocument { get; set; }
        public string Name { get; set; }
        public string TypeCode { get; set; }
        public string Purpose { get; set; }
        public Note Note { get; set; }
    }

    public class SellerTradeParty
    {
        public PostalTradeAddress PostalCITradeAddress { get; set; }
        public string Name { get; set; }
        public string TaxID { get; set; }
        public string BranchCode { get; set; }
        public string CompleteNumber { get; set; }
        public string URIID { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
    }

    public class BuyerTradeParty
    {
        public string PersonName { get; set; }
        public string Name { get; set; }
        public string TaxID { get; set; }
        public string BranchCode { get; set; }
        public string CompleteNumber { get; set; }
        public string URIID { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public PostalTradeAddress PostalTradeAddress { get; set; }
    }

    //public class IncludedSupplyChainTradeLineItem
    //{
        
    //}

    //public class ReferencedDocument
    //{

    //}

    public class ApplicableHeaderTradeSettlement
    {
        public SpecifiedTradeAllowanceCharge SpecifiedTradeAllowanceCharge { get; set; }
        public string InvoiceCurrencyCode { get; set; }
        public ApplicableTradeTax ApplicableTradeTax { get; set; }
        public SpecifiedTradeSettlementHeaderMonetarySummation SpecifiedTradeSettlementHeaderMonetarySummation { get; set; }
    }

    // Sub level class
    public class Note
    {
        public string Subject { get; set; }
        public string Content { get; set; }
    }

    public class PostalTradeAddress
    {
        public string LineOne { get; set; }
        public string LineTwo { get; set; }
        public string CountryID { get; set; }
        public string PostcodeCode { get; set; }
        public string CountrySubDivisionID { get; set; }
        public string CityID { get; set; }
        public string CitySubDivisionID { get; set; }
        public string Address { get; set; }
    }

    public class LineItem
    {
        public string LineID { get; set; }
        public string Name { get; set; }
        public string ChargeAmount { get; set; }
        public string BilledQuantity { get; set; }
        public string UnitCode { get; set; }
        public string UnitName { get; set; }
        public string ChargeIndicator { get; set; }
        public string ActualAmount { get; set; }
        public string NetLineTotalAmount { get; set; }
        public string GlobalID { get; set; }
        public string ProductID { get; set; }
    }

    public class RefDocs
    {
        public string IssuerAssignedID { get; set; }
        public string IssueDateTime { get; set; }
        public string ReferenceTypeCode { get; set; }
    }

    public class SpecifiedTradeAllowanceCharge
    {
        public string ChargeIndicator { get; set; }
        public string ActualAmount { get; set; }
    }

    public class ApplicableTradeTax
    {
        public string CalculatedRate { get; set; }
        public string BasisAmount { get; set; }
        public string VatAmount { get; set; }
        public string TypeCode { get; set; }
    }

    public class SpecifiedTradeSettlementHeaderMonetarySummation
    {
        public string LineTotalAmount { get; set; }
        public string GrandTotalAmountCharactor { get; set; }
        public string TaxTotalAmount { get; set; }
        public string GrandTotalAmount { get; set; }
    }
}
