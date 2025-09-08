using System.Text;
Console.OutputEncoding = Encoding.UTF8;
Console.WriteLine("Nhập a: ");
float a = float.Parse(Console.ReadLine());
Console.WriteLine("Nhập b: ");
float b = float.Parse(Console.ReadLine());
Console.WriteLine("Nhập c: ");
float c = float.Parse(Console.ReadLine());
Console.WriteLine(" Phương trình nhập vào là: {0}X*X + ({1})X + ({2}) = 0 ", a, b, c);
float delta = b * b- 4 * a * c;
if(delta < 0)
{
    Console.WriteLine(" Phương trình vô nghiệm");
}  
else if(delta > 0)
{
    double X1 = (-b + Math.Sqrt(delta)) / (2 * a);
    double X2 = (-b - Math.Sqrt(delta)) / (2 * a);
    Console.WriteLine(" Phương trình có 2 nghiệm phân biệt: {0}, {1}", X1,X2);
}    
else
{
    float X = -b / (2 * a);
    Console.WriteLine(" Phương trình có nghiệm kép: {0}", X);
}    