--user and roles
Use T3
go

SET IDENTITY_INSERT CMS_Roles ON
INSERT INTO CMS_Roles (ID, RoleName) VALUES (1, 'admin')
SET IDENTITY_INSERT CMS_Roles OFF

SET IDENTITY_INSERT CMS_Users ON
INSERT INTO CMS_Users (ID, UserName,Email,Password,Name,Surname,DateAdded) 
VALUES (1, 'admin', 'a@a','','Admin','',GETDATE())
SET IDENTITY_INSERT CMS_Users OFF


INSERT INTO CMS_UserRoles (UserID, RoleID) VALUES (1, 1)

GO

--INIT SETTINGS
INSERT INTO Settings (
ID,
CompanyName,
BusinessNumber,
[InvoiceIDFormat],[InvoiceIDGenerationMethod],Digits) VALUES(1,'','','F-SaleID',3,2)

--INSERT [dbo].[PurchaseType]

INSERT INTO PurchaseType (ID, Name) VALUES 
(0, 'Regjistrim i mallit'),
(1, 'Blerje e mallit'),
(2, 'Blerjet investive'),
(3, 'Blerje e shpenzimeve'),
(4, 'Not Debiti'),
(5, 'Kthimi i Blerjeve'),
(6, 'Ngarkesa e Kundert'),
(7, 'Porosit e mallit')

--SalesType
SET IDENTITY_INSERT SalesType ON
INSERT INTO SalesType (ID, Name) VALUES 
(1, 'Shitje Vendore'),
(2, 'Shitje EX'),
(3, 'Not Debiti'),
(4, 'Kthimi i Shitjeve'),
(5, 'Ngarkesa e Kundert'),
(6, 'Fletdergesat')

SET IDENTITY_INSERT SalesType OFF

-- [dbo].[PaymentMethod]
SET IDENTITY_INSERT PaymentMethod ON
INSERT INTO PaymentMethod (ID, Name) VALUES 
(1, 'Arke'),
(2, 'Xhirollogari'),
(3, 'Me pritje'),
(4, 'Parapagim')
SET IDENTITY_INSERT PaymentMethod OFF

--Units
SET IDENTITY_INSERT Units ON
INSERT INTO Units (ID, Name) VALUES 
(1, 'Kg'),
(2, 'Copë'),
(3, 'Pako'),
(4, 'Liter')
SET IDENTITY_INSERT Units OFF

--Categories
SET IDENTITY_INSERT [Categories] ON
INSERT INTO [Categories] (ID, Name) VALUES 
(1, 'All')
SET IDENTITY_INSERT [Categories] OFF

--PozicioniPasqyre
SET IDENTITY_INSERT PozicioniPasqyre ON
INSERT INTO PozicioniPasqyre (ID, Name) VALUES 
(1, 'Bilanci i gjendjes'),
(2, 'Pasqyra e te ardhurave')
SET IDENTITY_INSERT PozicioniPasqyre OFF

--GrupiKontabel
SET IDENTITY_INSERT GrupiKontabel ON
INSERT INTO GrupiKontabel (ID, Name) VALUES 
(1, 'Paraja'),
(2, 'Blerës'),
(3, 'Mallërat'),
(4, 'Kostoja e shitjes'),
(5, 'Pasuritë vijuese'),
(6, 'Parapagimet e dhëna'),
(7, 'Pasuritë fikse'),
(8, 'BZhvleresimet e akumuluara'),
(9, 'Pasuritë tjera fikse'),
(10, 'Furnitorë'),
(11, 'Detyrimet  rrjedhëse'),
(12, 'Parapagimet e marrura'),
(13, 'Detyrimet afategjate'),
(14, 'Ekuiteti'),
(15, 'Fitimi i akumuluar'),
(16, 'Terheqjet dhe deponimet'),
(17, 'Te hyrat operuese'),
(18, 'Shpenzimet operuese'),
(19, 'Shpenzimet e amortizimit'),
(20, 'Shpenzimet e zhvleresimit'),
(21, 'Shpenzimet e interesit'),
(22, 'Zërat jashtë bilancorë')

SET IDENTITY_INSERT GrupiKontabel OFF

--PaymentMethod
SET IDENTITY_INSERT PaymentType ON
INSERT INTO PaymentType (ID, Name,[Type]) VALUES 
(1, 'Pagesa Blerjes', 'D'),
(2, 'Pagesa Shpenzimeve', 'D'),
(3, 'Pagesa Shitjes', 'H'),
(4, 'Pages Avanci Blerje', 'D'),
(5, 'Pages Avanci Shitje', 'H'),
(6, 'Transfere tjera hyrje', 'H'),
(7, 'Transfere tjera dalje', 'D')

SET IDENTITY_INSERT PaymentType OFF


--PartnerType
SET IDENTITY_INSERT PartnerType ON
INSERT INTO PartnerType (ID, Name) VALUES 
(1, 'Partner'),
(2, 'Person Fizik'),
(3, 'Institucion'),
(4, 'OJQ'),
(5, 'Bank')
SET IDENTITY_INSERT PartnerType OFF

SET IDENTITY_INSERT Partners ON

INSERT INTO Partners(ID,Name,PartnerType,SaveAs,Customer) VALUES (2,'Qytetar',2,'Qytetar', 1)

SET IDENTITY_INSERT Partners OFF

--Countries
SET IDENTITY_INSERT Countries ON
INSERT INTO Countries(ID, Name, ISOCode) VALUES 
(1, 'Kosovë', '12'),
(2, 'Shqipëri','13')
SET IDENTITY_INSERT Countries OFF

--Cities
SET IDENTITY_INSERT Cities ON
INSERT INTO Cities(ID, Name, CountryID) VALUES 
(1, 'Gjilan', 1),
(2, 'Prishtinë',1),
(3, 'Prizren',1),
(4, 'Pejë',1)
SET IDENTITY_INSERT Cities OFF

SET IDENTITY_INSERT UserColumns ON
INSERT INTO UserColumns(Id, UserName, FormName, HColumns)VALUES
(1,  'admin','SalesList', 'ID,FiscalNo,VatNo,BusinessNo,Export,SaleType,Comment'),
(2,  'admin','SalesDetails', ''),
(3,  'admin','PurchasesList', 'ID,VatNo,TotalWithVat,SaveAs,CompanyName1'),
(4,  'admin','PurchaseDetails', 'ID,InvoiceID,RetailPrice'),
(5,  'admin','frmItems', 'ID,Description,Akciza,Category,Producers'),
(6,  'admin','frmPartnersList', 'ID,Name,Surname,Comment'),
(7,  'shites','SalesList', 'ID,FiscalNo,VatNo,BusinessNo,Export,SaleType,Comment'),
(8,  'shites','SalesDetails', ''),
(9,  'shites','PurchasesList', 'ID,VatNo,TotalWithVat,SaveAs,CompanyName1'),
(10, 'shites','PurchaseDetails', 'ID,Description,Akciza,Category,Producers'),
(11, 'shites','frmItems', 'ID,Description,Akciza,Category,Producers'),
(12, 'shites','frmPartnersList', 'ID,Name,Surname,Comment')
SET IDENTITY_INSERT UserColumns OFF


GO

INSERT INTO VatLevel(ID,Value,Active) VALUES
(0,0,1), (8,8,1),(15,15,0),(16,16,0),(18,18,0)

GO

--PlaniKontabel
SET IDENTITY_INSERT PlaniKontabel ON
INSERT INTO PlaniKontabel (ID, AccountNumber,Name, GrupiID, PozicioniID) VALUES 
(1     ,'10000','	Arka kryesore',1,1),
(2     ,'10099','	Arkat tjera',1,1),
(3     ,'10100','	Arka konto kalimtare',1,1),
(4     ,'10200','	NLB Prishtina',1,1),
(5     ,'10210','	Raiffeisen Bank',1,1),
(6     ,'10220','	ProAmountPaid Bank',1,1),
(7     ,'10230','	Banka Ekonomike',1,1),
(8     ,'10240','	BPB',1,1),
(9     ,'10250','	BKT Prishtina',1,1),
(10    ,'10260','	TEB Banka',1,1),
(11    ,'10270','	Ish Bankasi',1,1),
(12    ,'10300','	NLB POSS',1,1),
(13    ,'10310','	RBKO POSS',1,1),
(14    ,'10320','	PCB POSS',1,1),
(15    ,'10330','	BE POSS',1,1),
(16    ,'10340','	BPB POSS',1,1),
(17    ,'10350','	BKT POSS',1,1),
(18    ,'10360','	TEB POSS',1,1),
(19    ,'10370','	ISH POSS',1,1),
(20    ,'10400','	NLB USD',1,1),
(21    ,'10410','	RBKO USD',1,1),
(22    ,'10420','	PCB USD',1,1),
(23    ,'10430','	BE USD',1,1),
(24    ,'10440','	BPB USD',1,1),
(25    ,'10450','	BKT USD',1,1),
(26    ,'10460','	TEB USD',1,1),
(27    ,'10470','	ISH USD',1,1),
(28    ,'10500','	Paraja e bllokuar Garancion',1,1),
(29    ,'11000','	Llogaritë e arkëtueshme - Bleres',2,1),
(30    ,'11100','	Provizionimi i llogarive te arketueshme',2,1),
(31    ,'12000','	Malli',3,1),
(32    ,'12100','	Malli lënda e parë',3,1),
(33    ,'12300','	Kosto e mallit te shitur',4,2),
(34    ,'13000','	TVSH - Blerje', 5,1),
(35    ,'14000','	Avanset e dhëna - Mall',6,1),
(36    ,'14100','	Avanset e dhëna - Qera',6,1),
(37    ,'14200','	Huazimet e dhëna',6,1),
(38    ,'14500','	Parapagimet ne tremujorsha',5,1),
(39    ,'15000','	Patentat dhe te drejtat tjera',7,1),
(40    ,'16000','	Toka',7,1),
(41    ,'16100','	Asetet Kat I (4   ,5%)',7,1),
(42    ,'16200','   Asetet Kat II (4   ,20%)',7,1),
(43    ,'16300','	Asetet kat II (4   ,20%) Grup',7,1),
(44    ,'16400','	Asetet Kat III  (4   ,10%)',7,1),
(45    ,'16500','	Asetet - Granti',7,1),
(46    ,'17000','	Amortizimi i te drejtave',8,1),
(47    ,'18100','	Zhvleresimi i Aseteve 5%',8,1),
(48    ,'18200','	Zhvleresimi i Aseteve 20%',8,1),
(49    ,'18300','	Zhvleresimi i Aseteve 20% Grup',8,1),
(50    ,'18400','	Zhvleresimi i Aseteve 10%',	8,1),
(51    ,'18500','	Zhvleresimi i asesteve grant',8,1),
(52    ,'19500','	Mjetet tjera jo-rrjedhëse',9,1),
(53    ,'20000','	Llogarite e pagueshme  - Furnitor',10,1),
(54    ,'21000','	Detyrimet ndaj doganes',11,1),
(55    ,'21100','	Detyrimet ndaj akcizes',11,1),
(56    ,'21200','   TVSH ne dogane',11,1),
(57    ,'22000','	TVSH ne shitje',11,1),
(58    ,'23000','	Detyrimet ndaj tatimit ne fitim',11,1),
(59    ,'23400','	Obligimet per tatim ne fitim vjetor',11,1),
(60    ,'24000','	Detyrimi ndaj pagave', 11,1),
(61    ,'24001','	Detyrimi ndaj tatimit ne paga',11,1),
(62    ,'24100','	Detyrimi ndaj kontributeve punetori',11,1),
(63    ,'24101','	Detyrimi ndaj Kontributeve punedhenesi',11,1),
(64    ,'24200','	Detyrimet ndaj tatimit ne qira',11,1),
(65    ,'25000','	Detyrimet ndaj avanseve te marrura',12,1),
(66    ,'25200','   Huazimet e marrura',12,1),
(67    ,'26000','	Detyrimet ndaj grantit',11,1),
(68    ,'27000','	Detyrimet nga kreditë afatshkurte',13,1),
(69    ,'27100','	Detyrimet ndaj overdraftiti',11,1),
(70    ,'28000','	Te hyrat e shtyera',11,1),
(71    ,'29000','	Detyrimet ndaj kredive afatgjate',13,1),
(72    ,'30000','	Kapitali I pronareve',14,1),
(73    ,'31000','	Fitimi i mbajtur nga viti i kaluar',15,1),
(74    ,'32000','	Fitimi neto',15,1),
(75    ,'33000','	Terheqjet e pronarit',16,1),
(76    ,'34000','	Dividentat',16,1),
(77    ,'35000','	Rivleresimet',14,1),
(78    ,'40000','	Te hyrat nga shitja e mallrave',17,2),
(79    ,'41000','	Te hyrat nga sherbimet',17,2),
(80    ,'42000','	Te hyrat nga transporti',17,2),
(81    ,'42000','	Te hyrat nga transporti',17,2),
(82    ,'42000','	Te hyrat nga transporti',17,2),
(83    ,'43000','	Te hyrat tjera',17,2),
(84    ,'49000','	Zbritjet e lejuara - rabatet', 17,2),
(85    ,'50000','	Kosto e shitjes se mallrave',4,2),
(86    ,'51000','	Kosto e sherbimeve',4,2),
(87    ,'52000','	Kosto e transportit',4,2),
(88    ,'53000','	Kosto e shitjeve tjera',4,2),
(89    ,'60000','	Shpenzimet e zyres',18,2),
(90    ,'60100','	Shpenzimet e internetit',18,2),
(91    ,'60200','	Shpenzimet e telefonit',18,2),
(92    ,'60300','	Shpenzimet e rrymes',18,2),
(93    ,'60400','	Shpenzimet e pastrimit',18,2),
(94    ,'60401','	Shpenzimet e ujit',18,2),
(95    ,'60402','	Shpenzimet e parkingut',18,2),
(96    ,'60500','	Shpenzimet e qirase',	18	,2),
(97    ,'60600','	Shpenzimet e sigurimit te automjeteve',18,2),
(98    ,'60601','	Shpenzimet e sigurimit te objekteve',18,2),
(99    ,'60602','	Shpenzimet e sigurimeve shendetsore',18,2),
(100   ,'60700','	Shpenzimet juridike dhe te auditimit',18,2),
(101   ,'60750','	Shpenzimet e kontabilitetit',18,2),
(102   ,'60760','	Shpenzimet e keshillimeve',18,2),
(103   ,'60800','	Shpenzimet e taksave komunale',18,2),
(104   ,'61000','	Shpenzimet e derivateve',18,2),
(105   ,'61100','	Shpenzimet e shpedicionit',18,2),
(106   ,'61200','	Shpenzimet e transportimit',18,2),
(107   ,'61300','	Shpenzimet e terminalit',18,2),
(108   ,'61400','	Shpenzimet e fitosanitarisë',18,2),
(109   ,'61500','	Shpenzimet e inspektimit ne kufi',18,2),
(110   ,'61600','	Shpenzimet e kargos',18,2),
(111   ,'61700','	Shpenzimet e Tenderit',18,2),
(112   ,'62000','	Shpenzimet e pagave',18,2),
(113   ,'62100','	Shpenzimet e kontributeve pensionale',18,2),
(114   ,'62300','	Shpenzimet e antarsimeve',18,2),
(115   ,'62310','	Shpenzimet e licencave',18,2),
(116   ,'62400','	Shpenzimet e ngritjes profesionale',18,2),
(117   ,'63000','	Shpenzimet e mirembajtjes kat I',18,2),
(118   ,'63100','	Shpenzimet e mirembajtjes kat II',18,2),
(119   ,'63200','	Shpenzimet e mirembajtjes kat III',18,2),
(120   ,'64000','	Shpenzimet e provizioneve bankare',18,2),
(121   ,'65000','	Shpenzimet e reklames',18,2),
(122   ,'65100','	Shpenzimet e reprezantacionit',18,2),
(123   ,'65200','	Shpenzimet e udhetimit jasht vendit',18,2),
(124   ,'65300','	Shpenzimet e udhetimit  - transporti local',18,2),
(125   ,'65400','	Shpenzimet e ushqimit',18,2),
(126   ,'65500','	Shpenzimet per reklam ne gazeta',18,2),
(127   ,'68000','	Shpenzimet e borxheve te keqija',18,2),
(128   ,'68100','	Provizionimi i borxheve te keqija',18,2),
(129   ,'69000','	Donacionet',18,2),
(130   ,'69100','	Shpenzimet e dhuratave',18,2),
(131   ,'69200','	Bonuset',18,2),
(132   ,'70000','	Shpenzimet e amortizimit',19,2),
(133   ,'71000','	Shpenzimet e zhvleresimit kat I 5%',20,2),
(134   ,'72000','	Shpenzimet e zhvleresimit kat II 20%',20,2),
(135   ,'73000','	Shpenzimet e zhvleresimit kat III 10%',20,2),
(136   ,'80000','	Shpenzimet e overdraftit',21,2),
(137   ,'80100','	Shpenzimet e menaxhimit te kredive',21,2),
(138   ,'80200','   Shpenzimet e kredive',18,2),
(139   ,'81000','	Te hyrat nga granti',21,2),
(140   ,'82000','	Shpenzimet e grantiti - amortizimi',21,2),
(141   ,'88000','	Shpenzimet e papranuara',21,2),
(142   ,'89000','	Shpenzimet tatimit ne fitim',21,2),
(143   ,'90000','	Fitimi/humbja në shitjen e mjeteve',18,2)
SET IDENTITY_INSERT PlaniKontabel OFF






