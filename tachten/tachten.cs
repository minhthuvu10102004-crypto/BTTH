string s = "Bùi Nguyễn Hoàng Anh";

int vt1 = s.IndexOf(' ');
int vt2 = s.LastIndexOf(' ');

string name = s.Substring(vt2 + 1, s.Length - vt2 - 1);

Console.WriteLine(name); 
