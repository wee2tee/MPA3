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
        public DocumentDetail DocumentDetail { get; set; }
        public SellerTradeParty SellerTradeParty { get; set; }
        public BuyerTradeParty BuyerTradeParty { get; set; }
        public List<LineItem> IncludedSupplyChainTradeLineItem { get; set; }
        public List<RefDocs> ReferencedDocument { get; set; }
        public ApplicableHeaderTradeSettlement ApplicableHeaderTradeSettlement { get; set; }

        public JsonModel(string data_path, string docnum)
        {
            DbfTable dbf = new DbfTable(data_path);

            ArtrnDbf artrn = dbf.Artrn.Where(a => a.docnum == docnum).FirstOrDefault();
            ArmasDbf armas = dbf.Armas.Where(a => a.cuscod == artrn.cuscod).FirstOrDefault();
            List<StcrdDbf> stcrd = dbf.Stcrd.Where(s => s.docnum == docnum).ToList();
            List<IstabDbf> qucod = dbf.Istab.Where(i => i.tabtyp == "20" && stcrd.Select(s => s.tqucod).ToList<string>().Contains(i.typcod)).ToList();

            this.DocumentDetail = new DocumentDetail
            {
                ID = artrn.docnum, //string.Empty,
                CreationDateTime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff", CultureInfo.GetCultureInfo("en-US")), //string.Empty,
                IssueDateTime = artrn.docdat.Value.ToString("yyyy-MM-ddTHH:mm:ss.fff", CultureInfo.GetCultureInfo("en-US")), //string.Empty,
                SpecifiedCIDocument = string.Empty,
                Name = string.Empty,
                TypeCode = string.Empty,
                Purpose = string.Empty,
                Note = new Note
                {
                    Subject = string.Empty,
                    Content = string.Empty
                }
            };

            this.SellerTradeParty = new SellerTradeParty
            {
                PostalCITradeAddress = new PostalTradeAddress
                {
                    LineOne = string.Empty,
                    LineTwo = string.Empty,
                    CountryID = string.Empty,
                    PostcodeCode = string.Empty,
                    CountrySubDivisionID = string.Empty,
                    CityID = string.Empty,
                    CitySubDivisionID = string.Empty,
                    Address = string.Empty,
                },
                Name = string.Empty,
                TaxID = string.Empty,
                BranchCode = string.Empty,
                CompleteNumber = string.Empty,
                URIID = string.Empty,
                Telephone = string.Empty,
                Fax = string.Empty,
            };

            this.BuyerTradeParty = new BuyerTradeParty
            {
                PersonName = string.Empty,
                Name = string.Empty,
                TaxID = string.Empty,
                BranchCode = string.Empty,
                CompleteNumber = string.Empty,
                URIID = string.Empty,
                Telephone = string.Empty,
                Fax = string.Empty,
                PostalTradeAddress = new PostalTradeAddress
                {
                    CountryID = string.Empty,
                    LineOne = string.Empty,
                    LineTwo = string.Empty,
                    PostcodeCode = string.Empty,
                    CountrySubDivisionID = string.Empty,
                    CityID = string.Empty,
                    CitySubDivisionID = string.Empty,
                    Address = string.Empty
                }
            };

            this.IncludedSupplyChainTradeLineItem = new List<LineItem>();
            this.ReferencedDocument = new List<RefDocs>();

            this.ApplicableHeaderTradeSettlement = new ApplicableHeaderTradeSettlement
            {
                SpecifiedTradeAllowanceCharge = new SpecifiedTradeAllowanceCharge
                {
                    ChargeIndicator = "false",
                    ActualAmount = string.Empty
                },
                InvoiceCurrencyCode = string.Empty,
                ApplicableTradeTax = new ApplicableTradeTax
                {
                    CalculatedRate = "7.00",
                    BasisAmount = string.Empty,
                    TypeCode = "VAT"
                },
                SpecifiedTradeSettlementHeaderMonetarySummation = new SpecifiedTradeSettlementHeaderMonetarySummation
                {
                    LineTotalAmount = string.Empty,
                    GrandTotalAmountCharactor = string.Empty,
                    TaxTotalAmount = string.Empty,
                    GrandTotalAmount = string.Empty
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
                File.WriteAllText(dest_file, this.ToString(), Encoding.UTF8);
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
