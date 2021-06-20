create table UserAccount
(
	IDAcc varchar(10) primary key not null,
	UserName nvarchar(50),
	Password varchar(50), 
	Status varchar(30)
)

insert into  UserAccount
values	('A001','admin','admin','Active'),
		('A002','admin1','admin1','Active'),
		('A003','admin2','admin2','Blocked'),
		('A004','quoc','quoc','Active')
create table Category
(
	IDCate varchar(10) primary key not null ,
	Name nvarchar(50) ,
	Description nvarchar(100)
)
insert into  Category
values	('C001',N'Trinh thám',N'Một tiểu loại của tiểu thuyết phiêu lưu, kịch tính'),
		('C002',N'Khoa học',N'Hệ thống kiến thức về những định luật của thế giới'),
		('C003',N'Giải trí',N'Nhằm giải tỏa căng thẳng trí não, tạo sự hứng thú cho con người'),
		('C004',N'Nhân văn',N' Nghiên cứu về văn hóa con người')
create table Product
(
	IDPro varchar(10) primary key not null ,
	IDCate varchar(10) foreign key references Category(IDCate),
	Name nvarchar(50),
	UnitCost decimal(18, 0),
	Quantity int,  
	Image varchar(MAX), 
	Description nvarchar(50),
	Status varchar(40)
)
insert into Product
values	('P001','C001',N'Thám tử lừng danh Connan',75000,100,'https://cdn-images.kiotviet.vn/baonambookstore/70aae7f039f04df69c98076a12782dec.jpg',N'Đây là sách trinh thám bán chạy nhất','still for sell'),
		('P002','C002',N'Ngân hà và những thiên hà khác',195000,200,'https://dongtay.vn/fileupload/images/3%20NGAN%20HA%20VA%20NHUNG%20THIEN%20HA%20KHAC-01.jpg',N'Đây là sách khoa học bán chạy nhất','still for sell'),
		('P003','C003',N'Hoàng tử mây',145000,150,'https://petrotimes.vn/stores/news_dataimages/petrotimes/062012/08/07/hoang-tu-may1-477x63620120821140827.jpg',N'Đây là sách giải trí bán chạy nhất','sold out'),
		('P004','C004',N'Tôi thấy hoa vàng trên cỏ xanh',87000,250,'https://nld.mediacdn.vn/k:2016/bia-sach-1458918936219/sach-van-hoc-soi-dong-tro-lai.jpg',N'Đây là sách bán chạy nhất','still for sell'),
		('P005','C004',N'Nguyễn Nhật Ánh và Tôi',97000,153,'https://nld.mediacdn.vn/k:2016/bia-sach-1458918936219/sach-van-hoc-soi-dong-tro-lai.jpg',N'Đây là sách bán chạy nhất','still for sell')