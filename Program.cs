using Grpc.Core;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection.Emit;

if (FileUpload1.HasFile)
{
    if (Path.GetExtension(FileUpload1.PostedFile.FileName) == ".jpg" || Path.GetExtension(FileUpload1.PostedFile.FileName) == ".png")
    {
        Random rstgele = new Random();
        string ResimUzantisi = Path.GetExtension(FileUpload1.PostedFile.FileName);
        string ResimAdi = FileUpload1.PostedFile.FileName + rstgele.Next(99999999, 999999999) + ResimUzantisi;
        //Geçici olarak FileUpload nesnemizdeki resmi Resimler dizinine kayıt ediyoruz.
        FileUpload1.SaveAs(Server.MapPath("~\\Resimler\\") + ResimAdi);
        //Şimdi ise bu kayıt ettiğimiz resmi Bitmap nesnesi şeklinde alıyoruz.
        Bitmap Resim = new Bitmap(Server.MapPath("~\\Resimler\\") + ResimAdi);
        int Genislik = 262;
        int Yukseklik = 110;
        //Boyutlarını veriyoruz.
        Size Boyut = new Size(Genislik, Yukseklik);
        //Resmi boyutlandırıyoruz.
        Bitmap BoyutlandirilmisResim = new Bitmap(Resim, Boyut);
        string BoyutlanmisKayit = "~\\Resimler\\BoyutluResimler\\" + ResimAdi;
        //Boyutlanmış resmi Resimler/BoyutluResimler dizinine kayıt ediyoruz.
        BoyutlandirilmisResim.Save(Server.MapPath(BoyutlanmisKayit), ImageFormat.Jpeg);
        Resim.Dispose();
        BoyutlandirilmisResim.Dispose();
        //Geçici olarak kaydedilen resmi siliyoruz.
        FileInfo IlkResimDosyasi = new FileInfo(Server.MapPath("~\\Resimler\\") + ResimAdi);
        IlkResimDosyasi.Delete();
    }
    else
    {
        Label1.Text = "Lütfen .jpg ve .png uzantılı dosya seçiniz.";
    }

}