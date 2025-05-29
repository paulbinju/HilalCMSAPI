using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class two : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("SET IDENTITY_INSERT Lookups ON");
            migrationBuilder.Sql("insert into Lookups (LookupId,GroupName,Title,OrderNo,Active) values(1,'Publications','Tradearabia', 1, 1)");
            migrationBuilder.Sql("insert into Lookups (LookupId,GroupName,Title,OrderNo,Active) values(2,'Publications','Gulf Construction', 2, 1)");
            migrationBuilder.Sql("insert into Lookups (LookupId,GroupName,Title,OrderNo,Active) values(3,'Publications','Gulf Industry', 3, 1)");
            migrationBuilder.Sql("insert into Lookups (LookupId,GroupName,Title,OrderNo,Active) values(4,'Publications','Oil and Gas News', 4, 1)");
            migrationBuilder.Sql("insert into Lookups (LookupId,GroupName,Title,OrderNo,Active) values(5,'Publications','Travel and Tourism News', 5, 1)");
            migrationBuilder.Sql("insert into Lookups (LookupId,GroupName,Title,OrderNo,Active) values(6,'Publications','Arabian Business Community', 6, 1)");
            migrationBuilder.Sql("insert into Lookups (LookupId,GroupName,Title,OrderNo,Active) values(7,'Publications','Gulf Weekly', 7, 1)");
            migrationBuilder.Sql("insert into Lookups (LookupId,GroupName,Title,OrderNo,Active) values(8,'Publications','Gulf Daily News', 8, 1)");
            migrationBuilder.Sql("insert into Lookups (LookupId,GroupName,Title,OrderNo,Active) values(9,'Roles','Administrator', 1, 1)");
            migrationBuilder.Sql("insert into Lookups (LookupId,GroupName,Title,OrderNo,Active) values(10,'Roles','Chief Editor', 2, 1)");
            migrationBuilder.Sql("insert into Lookups (LookupId,GroupName,Title,OrderNo,Active) values(11,'Roles','Sub Editor', 3, 1)");
            migrationBuilder.Sql("insert into Lookups (LookupId,GroupName,Title,OrderNo,Active) values(12,'ArticleTypes','Latest News', 1, 1)");
            migrationBuilder.Sql("insert into Lookups (LookupId,GroupName,Title,OrderNo,Active) values(13,'ArticleTypes','Essentials', 2, 1)");
            migrationBuilder.Sql("insert into Lookups (LookupId,GroupName,Title,OrderNo,Active) values(14,'ArticleTypes','Issue Article', 3, 1)");
            migrationBuilder.Sql("insert into Lookups (LookupId,GroupName,Title,OrderNo,Active) values(15,'ArticleExtensionTypes','Text block', 1, 1)");
            migrationBuilder.Sql("insert into Lookups (LookupId,GroupName,Title,OrderNo,Active) values(16,'ArticleExtensionTypes','Image', 2, 1)");
            migrationBuilder.Sql("insert into Lookups (LookupId,GroupName,Title,OrderNo,Active) values(17,'ArticleExtensionTypes','Video', 3, 1)");
            migrationBuilder.Sql("insert into Lookups (LookupId,GroupName,Title,OrderNo,Active) values(18,'Countries','Rest of the World', 1, 1)");
            migrationBuilder.Sql("insert into Lookups (LookupId,GroupName,Title,OrderNo,Active) values(19,'Countries','Bahrain', 2, 1)");
            migrationBuilder.Sql("insert into Lookups (LookupId,GroupName,Title,OrderNo,Active) values(20,'Countries','Kuwait', 3, 1)");
            migrationBuilder.Sql("insert into Lookups (LookupId,GroupName,Title,OrderNo,Active) values(21,'Countries','Oman', 4, 1)");
            migrationBuilder.Sql("insert into Lookups (LookupId,GroupName,Title,OrderNo,Active) values(22,'Countries','Qatar', 5, 1)");
            migrationBuilder.Sql("insert into Lookups (LookupId,GroupName,Title,OrderNo,Active) values(23,'Countries','Saudi Arabia', 6, 1)");
            migrationBuilder.Sql("insert into Lookups (LookupId,GroupName,Title,OrderNo,Active) values(24,'Countries','United Arab Emirates', 7, 1)");
            migrationBuilder.Sql("insert into Lookups (LookupId,GroupName,Title,OrderNo,Active) values(25,'NLGC','Top Story', 1, 1)");
            migrationBuilder.Sql("insert into Lookups (LookupId,GroupName,Title,OrderNo,Active) values(26,'NLGC','Latest News', 2, 1)");
            migrationBuilder.Sql("insert into Lookups (LookupId,GroupName,Title,OrderNo,Active) values(27,'NLGC','Around the World', 3, 0)");
            migrationBuilder.Sql("insert into Lookups (LookupId,GroupName,Title,OrderNo,Active) values(28,'NLGC','New Products', 4, 0)");
            migrationBuilder.Sql("insert into Lookups (LookupId,GroupName,Title,OrderNo,Active) values(29,'NLGI','Top Story', 1, 1)");
            migrationBuilder.Sql("insert into Lookups (LookupId,GroupName,Title,OrderNo,Active) values(30,'NLGI','Latest News', 2, 1)");
            migrationBuilder.Sql("insert into Lookups (LookupId,GroupName,Title,OrderNo,Active) values(31,'NLGI','Blast from the Past', 3, 0)");
            migrationBuilder.Sql("insert into Lookups (LookupId,GroupName,Title,OrderNo,Active) values(32,'NLGI','New Products', 4, 0)");
            migrationBuilder.Sql("insert into Lookups (LookupId,GroupName,Title,OrderNo,Active) values(33,'NLGI','Profile and Events', 5, 0)");
            migrationBuilder.Sql("insert into Lookups (LookupId,GroupName,Title,OrderNo,Active) values(34,'NLOGN','Top Story', 1, 1)");
            migrationBuilder.Sql("insert into Lookups (LookupId,GroupName,Title,OrderNo,Active) values(35,'NLOGN','Latest News', 2, 1)");
            migrationBuilder.Sql("insert into Lookups (LookupId,GroupName,Title,OrderNo,Active) values(36,'NLOGN','Video', 3, 0)");
            migrationBuilder.Sql("insert into Lookups (LookupId,GroupName,Title,OrderNo,Active) values(37,'NLOGN','Brent', 4, 0)");
            migrationBuilder.Sql("insert into Lookups (LookupId,GroupName,Title,OrderNo,Active) values(38,'NLOGN','Analysis', 5, 0)");
            migrationBuilder.Sql("insert into Lookups (LookupId,GroupName,Title,OrderNo,Active) values(39,'NLOGN','People', 6, 0)");
            migrationBuilder.Sql("insert into Lookups (LookupId,GroupName,Title,OrderNo,Active) values(40,'NLOGN','Profile & Events', 7, 0)");
            migrationBuilder.Sql("insert into Lookups (LookupId,GroupName,Title,OrderNo,Active) values(41,'NLTTN','Top Story', 1, 1)");
            migrationBuilder.Sql("insert into Lookups (LookupId,GroupName,Title,OrderNo,Active) values(42,'NLTTN','Latest News', 2, 1)");
            migrationBuilder.Sql("insert into Lookups (LookupId,GroupName,Title,OrderNo,Active) values(43,'NLTTN','Blast from the Past', 3, 0)");
            migrationBuilder.Sql("insert into Lookups (LookupId,GroupName,Title,OrderNo,Active) values(44,'NLTTN','New Products', 4, 0)");
            migrationBuilder.Sql("insert into Lookups (LookupId,GroupName,Title,OrderNo,Active) values(45,'NLTTN','Profile and Events', 5, 0)");
            migrationBuilder.Sql("insert into Lookups (LookupId,GroupName,Title,OrderNo,Active) values(46,'NLABC','Business News', 1, 1)");
            migrationBuilder.Sql("insert into Lookups (LookupId,GroupName,Title,OrderNo,Active) values(47,'NLABC','Analysis and Interviews', 2, 1)");
            migrationBuilder.Sql("insert into Lookups (LookupId,GroupName,Title,OrderNo,Active) values(48,'NLABC','Premium Partners', 3, 0)");
            migrationBuilder.Sql("insert into Lookups (LookupId,GroupName,Title,OrderNo,Active) values(49,'NLABC','Community News', 4, 0)");
            migrationBuilder.Sql("insert into Lookups (LookupId,GroupName,Title,OrderNo,Active) values(50,'NLABC','Project Focus', 5, 0)");
            migrationBuilder.Sql("insert into Lookups (LookupId,GroupName,Title,OrderNo,Active) values(51,'NLABC','Tenders', 6, 0)");
            migrationBuilder.Sql("SET IDENTITY_INSERT Lookups OFF");
            migrationBuilder.Sql("insert into Categories (categorycode,categoryname,publicationid) values('REAL','Analysis, Interviews, Opinions',1)");
            migrationBuilder.Sql("insert into Categories (categorycode,categoryname,publicationid) values('BRK','Breaking News',1)");
            migrationBuilder.Sql("insert into Categories (categorycode,categoryname,publicationid) values('CONS','Construction & Real Estate',1)");
            migrationBuilder.Sql("insert into Categories (categorycode,categoryname,publicationid) values('EDU','Education, HR & Training',1)");
            migrationBuilder.Sql("insert into Categories (categorycode,categoryname,publicationid) values('OGN','Energy, Oil & Gas',1)");
            migrationBuilder.Sql("insert into Categories (categorycode,categoryname,publicationid) values('BANK','Finance & Capital Market',1)");
            migrationBuilder.Sql("insert into Categories (categorycode,categoryname,publicationid) values('LAW','Government & Laws',1)");
            migrationBuilder.Sql("insert into Categories (categorycode,categoryname,publicationid) values('HEAL','Health & Environment',1)");
            migrationBuilder.Sql("insert into Categories (categorycode,categoryname,publicationid) values('IND','Industry, Logistics & Shipping',1)");
            migrationBuilder.Sql("insert into Categories (categorycode,categoryname,publicationid) values('INTNEWS','INTERNATIONAL NEWS',1)");
            migrationBuilder.Sql("insert into Categories (categorycode,categoryname,publicationid) values('IT','IT & Telecommunications',1)");
            migrationBuilder.Sql("insert into Categories (categorycode,categoryname,publicationid) values('LIFE','Lifestyle',1)");
            migrationBuilder.Sql("insert into Categories (categorycode,categoryname,publicationid) values('MEDIA','Media & Promotion',1)");
            migrationBuilder.Sql("insert into Categories (categorycode,categoryname,publicationid) values('MISC','Miscellaneous',1)");
            migrationBuilder.Sql("insert into Categories (categorycode,categoryname,publicationid) values('MTR','Motoring',1)");
            migrationBuilder.Sql("insert into Categories (categorycode,categoryname,publicationid) values('PIC','Picture of the Day',1)");
            migrationBuilder.Sql("insert into Categories (categorycode,categoryname,publicationid) values('RET','Retail & Wholesale',1)");
            migrationBuilder.Sql("insert into Categories (categorycode,categoryname,publicationid) values('TTN','Travel, Tourism & Hospitality',1)");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,5,11,'Compressors')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,5,11,'Sealing Solutions')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,5,11,'Paints & Coatings')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,5,11,'Pumps')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,5,11,'Turbines')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,5,11,'Tanks')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,5,11,'Pressures Vessels')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,5,11,'Pipes')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,5,11,'Valves & Actuators')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,5,11,'Heat Exchangers')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,5,11,'Automation & AI')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,5,11,'Rigs')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,5,11,'Techonology')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,5,11,'Geophysical Services')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,5,11,'Tech Talks')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,5,11,'Logistics & Transport')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,5,11,'Artificial Lift systems')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,5,11,'Marine & Offshore')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,5,11,'Environment')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,5,11,'Renewables')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,5,11,'Emerging Trends')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,5,11,'Drilling – Offshore & Onshore')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,12,'Ground Engineering')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,12,'Handtools')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,12,'Instrumentation')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,12,'Interiors')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,12,'Lifts and Escalators')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,12,'Lighting')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,12,'Plant & Heavy Machinery')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,12,'3D Printing')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,12,'BIM')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,12,'Bricks and Blocks')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,12,'Demolition')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,12,'Fasteners')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,12,'AI')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,12,'Furniture & Fittings')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,12,'Power Tools')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,12,'Prefabricated Buildings')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,12,'Training')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,12,'Roofing')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,12,'Scaffolding')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,12,'Sealants')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,12,'Adhesives')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,12,'Sustainable Buildings')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,12,'Glass')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,12,'Tech Talks')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,11,'Utilities Construction')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,11,'Hotel Construction')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,11,'Airport Construction')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,11,'Industrial Construction')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,11,'Real Estate')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,11,'Petrochemical Facilities')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,11,'Digitalisation')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,11,'Tourism Facilities')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,11,'Sustainability')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,11,'Facilities Management')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,11,'Appointments')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,11,'Plant & Equipment')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,11,'Roads & Bridges')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,11,'Railway Construction')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,11,'Contracts & Tenders')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,11,'Acquisitions')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,11,'EPC')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,11,'Corporate News')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,11,'Technology')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,11,'New Products')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,11,'Analysis')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,11,'Labour & Safety')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,11,'Infrastructure')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,11,'Statistics & Data')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,11,'Building Materials')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,11,'Furniture & Fittings')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,11,'Contracting')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,11,'Construction & Engineering')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,11,'Smart Cities')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,11,'Residential Construction')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,11,'Architecture & Design')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,11,'Manufacturers & Suppliers')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,11,'Metal Fabrication')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,11,'Events')");
            migrationBuilder.Sql("insert into subcategories(publicationid,categoryid,articletypeid,subcategoryname) values(1,3,11,'Finance')");
            migrationBuilder.Sql("insert into Users(name,emailid,password,roleid) values('Ahmed Suleiman','ahmed.suleiman@tradearabia.net','123456',9)");
            migrationBuilder.Sql("insert into Users(name,emailid,password,roleid) values('Ali Mubarak','ali.mubarak@tradearabia.net','123456',9)");
            migrationBuilder.Sql("insert into Users(name,emailid,password,roleid) values('Sree Bhat','sree.bhat@tradearabia.net','123456',10)");
            migrationBuilder.Sql("insert into Users(name,emailid,password,roleid) values('Beena Gonsalvs','beena.gonsalvas@tradearabia.net','123456',10)");
            migrationBuilder.Sql("insert into Users(name,emailid,password,roleid) values('Sushil Nair','sushil.nair@tradearabia.net','123456',11)");
            migrationBuilder.Sql("insert into Users(name,emailid,password,roleid) values('Ansar S','ansar.s@tradearabia.net','123456',11)");
            migrationBuilder.Sql("insert into Users(name,emailid,password,roleid) values('Binju Paul','binju.paul@tradearabia.net','123456',9)");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
