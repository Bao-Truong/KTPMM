--------------------------
Character.cs: cá nhân mỗi người trong 1 đội (tính cả HLV, trợ lý HLV, SSV, cầu thủ) (role theo thứ tự t cho là 1,2,3,4 của mỗi người)

---------------------------
TeamMatch.cs: tính cho là 1 nhóm (gồm số lượng như trong mô tả)
Có các method:
	+RegisterTeam(int HLV, int TLHLV, int SSV, int CauThu) để tự động tạo 1 nhóm (rỗng thông tin)
	+checkComponent(int HLV, int TLHLV, int SSV, int CauThu) để kiểm tra cái số lượng có thoả như mô tả yêu cầu của 1 nhóm không
	+getscore(string s): gán điểm cho đội đó, nếu nó thắng,thua,hoà (Hàm này dc gọi trong Summary)
	+checkArea(): tính dùng để kiểm tra vùng miền, mà tạm thời chưa làm xg
-> chưa kiểm tra gì hết, toàn dữ liệu ma, ko lấy từ database
---------------------------
BoardMatch.cs: dùng cho cái Phân Bảng đấu ở vòng loại
các Method:
	+assignBoard(String Boardid, int Teamid): dùng để gán 1 nhóm vào 1 bảng
	+validto_AddThisBoard_orNot(boaradid): kt mỗi bảng đấu đã full chưa(4 nhóm)
---------------------------
Summary.cs: tính làm là để tổng kết 1 trận đấu
các Method:
	+whowin(int a,int b): a>b thì return 1, a<b thì return 2; coi a hay b lớn hơn thoi; a,b là goal của teamA và teamB
	+summary():để cộng điểm cho TeamA, TeamB, dùng kèm theo cái TeamMatch.getscore()


---------------------------
winner.cs: bỏ qua đi, chắc xoá.
---------------------------
Database.cs: dùng để thiết lập vài thứ của DB, thay đổi đường dẫn trước khi dùng trong lệnh con.connection(....)
Các method:
	+connect(): connect tới database, ko cần gọi, lúc tạo new Database() t cho nó chạy ở constructor rui
	+exeSQL(string sql): thực hiện câu lệnh SQL truyền vào cho nó cái String
	+readSQL(String sql): return cái SqldataReader, xem vd mẫu trong hàm CheckArea() của TeamMatch.cs
	+disconnect(): disconnect sau khi truy vấn

---------------------------