namespace AssetTracker.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssetLocation",
                c => new
                    {
                        AssetLocationID = c.Int(nullable: false, identity: true),
                        OrganizationBranchID = c.Int(nullable: false),
                        AssetLocationName = c.String(),
                        ShortName = c.String(),
                    })
                .PrimaryKey(t => t.AssetLocationID)
                .ForeignKey("dbo.OrganizationBranch", t => t.OrganizationBranchID, cascadeDelete: true)
                .Index(t => t.OrganizationBranchID);
            
            CreateTable(
                "dbo.OrganizationBranch",
                c => new
                    {
                        OrganizationBranchID = c.Int(nullable: false, identity: true),
                        OrganizationID = c.Int(nullable: false),
                        OrganizationBranchName = c.String(nullable: false, maxLength: 200, unicode: false),
                        OrganizatioBranchShortName = c.String(nullable: false, maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.OrganizationBranchID)
                .ForeignKey("dbo.Organization", t => t.OrganizationID, cascadeDelete: true)
                .Index(t => t.OrganizationID);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        OrganizationBranchID = c.Int(nullable: false),
                        DepartmentName = c.String(nullable: false, maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.DepartmentID)
                .ForeignKey("dbo.OrganizationBranch", t => t.OrganizationBranchID, cascadeDelete: true)
                .Index(t => t.OrganizationBranchID);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        DepartmentID = c.Int(nullable: false),
                        EmployeeName = c.String(nullable: false, maxLength: 150, unicode: false),
                        DesignationID = c.Int(nullable: false),
                        ContactNo = c.String(nullable: false, maxLength: 25, unicode: false),
                        Email = c.String(nullable: false, maxLength: 70, unicode: false),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.Department", t => t.DepartmentID, cascadeDelete: true)
                .ForeignKey("dbo.Designation", t => t.DesignationID, cascadeDelete: true)
                .Index(t => t.DepartmentID)
                .Index(t => t.DesignationID);
            
            CreateTable(
                "dbo.Designation",
                c => new
                    {
                        DesignationID = c.Int(nullable: false, identity: true),
                        DesignationName = c.String(nullable: false, maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.DesignationID);
            
            CreateTable(
                "dbo.Organization",
                c => new
                    {
                        OrganizationID = c.Int(nullable: false, identity: true),
                        OrganizationName = c.String(nullable: false, maxLength: 150, unicode: false),
                        OrganizationShortName = c.String(nullable: false, maxLength: 3, unicode: false),
                        OrganizationLocation = c.String(nullable: false, maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.OrganizationID);
            
            CreateTable(
                "dbo.AssetPurchaseDetail",
                c => new
                    {
                        AssetPurchaseDetailID = c.Int(nullable: false, identity: true),
                        AssetPurchaseHeaderID = c.Int(nullable: false),
                        ProductCategoryID = c.Int(nullable: false),
                        Quantity = c.Double(nullable: false),
                        UnitPrice = c.Double(nullable: false),
                        IsWarranty = c.Boolean(nullable: false),
                        WarrantyPeriod = c.Double(nullable: false),
                        WarrantyPeriodUnitID = c.Double(nullable: false),
                        WarrantyPeriodUnit_WarrantyPeriodUnitID = c.Int(),
                    })
                .PrimaryKey(t => t.AssetPurchaseDetailID)
                .ForeignKey("dbo.AssetPurchaseHeader", t => t.AssetPurchaseHeaderID, cascadeDelete: true)
                .ForeignKey("dbo.WarrantyPeriodUnit", t => t.WarrantyPeriodUnit_WarrantyPeriodUnitID)
                .Index(t => t.AssetPurchaseHeaderID)
                .Index(t => t.WarrantyPeriodUnit_WarrantyPeriodUnitID);
            
            CreateTable(
                "dbo.AssetPurchaseDetailSerialNumber",
                c => new
                    {
                        AssetPurchaseDetailSerialNumberID = c.Int(nullable: false, identity: true),
                        PerchaseDetailID = c.Int(nullable: false),
                        SerialNumber = c.String(nullable: false),
                        AssetPurchaseDetail_AssetPurchaseDetailID = c.Int(),
                    })
                .PrimaryKey(t => t.AssetPurchaseDetailSerialNumberID)
                .ForeignKey("dbo.AssetPurchaseDetail", t => t.AssetPurchaseDetail_AssetPurchaseDetailID)
                .Index(t => t.AssetPurchaseDetail_AssetPurchaseDetailID);
            
            CreateTable(
                "dbo.AssetPurchaseHeader",
                c => new
                    {
                        AssetPurchaseHeaderID = c.Int(nullable: false, identity: true),
                        VendorID = c.Int(nullable: false),
                        PurchasedOn = c.DateTime(nullable: false),
                        PurchasedBy = c.Int(nullable: false),
                        OrganizationBranchID = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedBy = c.Int(),
                        LastModifiedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.AssetPurchaseHeaderID)
                .ForeignKey("dbo.OrganizationBranch", t => t.OrganizationBranchID, cascadeDelete: true)
                .Index(t => t.OrganizationBranchID);
            
            CreateTable(
                "dbo.WarrantyPeriodUnit",
                c => new
                    {
                        WarrantyPeriodUnitID = c.Int(nullable: false, identity: true),
                        WarrantyPeriodUnitName = c.String(nullable: false, maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.WarrantyPeriodUnitID);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        GeneralCategoryID = c.Int(nullable: false),
                        CategoryName = c.String(nullable: false, maxLength: 150, unicode: false),
                        CategoryCode = c.String(nullable: false, maxLength: 3, unicode: false),
                        CategoryDescription = c.String(nullable: false, maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.CategoryID)
                .ForeignKey("dbo.GeneralCategory", t => t.GeneralCategoryID, cascadeDelete: true)
                .Index(t => t.GeneralCategoryID);
            
            CreateTable(
                "dbo.GeneralCategory",
                c => new
                    {
                        GeneralCategoryID = c.Int(nullable: false, identity: true),
                        GeneralCategoryName = c.String(nullable: false, maxLength: 150, unicode: false),
                        GeneralCategoryCode = c.String(nullable: false, maxLength: 2, unicode: false),
                    })
                .PrimaryKey(t => t.GeneralCategoryID);
            
            CreateTable(
                "dbo.SubCategory",
                c => new
                    {
                        SubCategoryID = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(nullable: false),
                        SubCategoryName = c.String(nullable: false, maxLength: 150, unicode: false),
                        SubCategoryCode = c.String(nullable: false, maxLength: 150, unicode: false),
                        SubCategoryDescription = c.String(nullable: false, maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.SubCategoryID)
                .ForeignKey("dbo.Category", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.DetailCategory",
                c => new
                    {
                        DetailCategoryID = c.Int(nullable: false, identity: true),
                        SubCategoryID = c.Int(nullable: false),
                        DetailCategoryName = c.String(nullable: false, maxLength: 8000, unicode: false),
                        DetailCategoryCode = c.String(nullable: false, maxLength: 8000, unicode: false),
                        DetailCategoryDescription = c.String(nullable: false, maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.DetailCategoryID)
                .ForeignKey("dbo.SubCategory", t => t.SubCategoryID, cascadeDelete: true)
                .Index(t => t.SubCategoryID);
            
            CreateTable(
                "dbo.Vendor",
                c => new
                    {
                        VendorID = c.Int(nullable: false, identity: true),
                        VendorName = c.String(nullable: false, maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.VendorID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DetailCategory", "SubCategoryID", "dbo.SubCategory");
            DropForeignKey("dbo.SubCategory", "CategoryID", "dbo.Category");
            DropForeignKey("dbo.Category", "GeneralCategoryID", "dbo.GeneralCategory");
            DropForeignKey("dbo.AssetPurchaseDetail", "WarrantyPeriodUnit_WarrantyPeriodUnitID", "dbo.WarrantyPeriodUnit");
            DropForeignKey("dbo.AssetPurchaseHeader", "OrganizationBranchID", "dbo.OrganizationBranch");
            DropForeignKey("dbo.AssetPurchaseDetail", "AssetPurchaseHeaderID", "dbo.AssetPurchaseHeader");
            DropForeignKey("dbo.AssetPurchaseDetailSerialNumber", "AssetPurchaseDetail_AssetPurchaseDetailID", "dbo.AssetPurchaseDetail");
            DropForeignKey("dbo.OrganizationBranch", "OrganizationID", "dbo.Organization");
            DropForeignKey("dbo.Department", "OrganizationBranchID", "dbo.OrganizationBranch");
            DropForeignKey("dbo.Employee", "DesignationID", "dbo.Designation");
            DropForeignKey("dbo.Employee", "DepartmentID", "dbo.Department");
            DropForeignKey("dbo.AssetLocation", "OrganizationBranchID", "dbo.OrganizationBranch");
            DropIndex("dbo.DetailCategory", new[] { "SubCategoryID" });
            DropIndex("dbo.SubCategory", new[] { "CategoryID" });
            DropIndex("dbo.Category", new[] { "GeneralCategoryID" });
            DropIndex("dbo.AssetPurchaseHeader", new[] { "OrganizationBranchID" });
            DropIndex("dbo.AssetPurchaseDetailSerialNumber", new[] { "AssetPurchaseDetail_AssetPurchaseDetailID" });
            DropIndex("dbo.AssetPurchaseDetail", new[] { "WarrantyPeriodUnit_WarrantyPeriodUnitID" });
            DropIndex("dbo.AssetPurchaseDetail", new[] { "AssetPurchaseHeaderID" });
            DropIndex("dbo.Employee", new[] { "DesignationID" });
            DropIndex("dbo.Employee", new[] { "DepartmentID" });
            DropIndex("dbo.Department", new[] { "OrganizationBranchID" });
            DropIndex("dbo.OrganizationBranch", new[] { "OrganizationID" });
            DropIndex("dbo.AssetLocation", new[] { "OrganizationBranchID" });
            DropTable("dbo.Vendor");
            DropTable("dbo.DetailCategory");
            DropTable("dbo.SubCategory");
            DropTable("dbo.GeneralCategory");
            DropTable("dbo.Category");
            DropTable("dbo.WarrantyPeriodUnit");
            DropTable("dbo.AssetPurchaseHeader");
            DropTable("dbo.AssetPurchaseDetailSerialNumber");
            DropTable("dbo.AssetPurchaseDetail");
            DropTable("dbo.Organization");
            DropTable("dbo.Designation");
            DropTable("dbo.Employee");
            DropTable("dbo.Department");
            DropTable("dbo.OrganizationBranch");
            DropTable("dbo.AssetLocation");
        }
    }
}
