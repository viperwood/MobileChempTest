using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MobileS4Chemp;

public partial class InfoPatientPage : ContentPage
{
    public InfoPatientPage()
    {
        InitializeComponent();
    }

    private async void SearchButton(object? sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(EntryCode.Text))
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage responseMessage = await client.GetAsync($"http://10.0.2.2:5298/api/FullInfoPatient/GetFullInfo?patient={EntryCode.Text}");
                string context = await responseMessage.Content.ReadAsStringAsync();
                List<FullInfo> info = JsonConvert.DeserializeObject<List<FullInfo>>(context)!.ToList();
                if (responseMessage.IsSuccessStatusCode)
                {
                    LabelNumbermedcart.Text = info[0].Numbermedcart.ToString()!;
                    LabelNamegender.Text = info[0].Namegender!;
                    LabelNameuser.Text = info[0].Nameuser!;
                    LabelPhone.Text = info[0].Phone!;
                    LabelAdres.Text = info[0].Adres!;
                    LabelEmailuser.Text = info[0].Emailuser!;
                    LabelFoto.Text = info[0].Foto!;
                    LabelPasportn.Text = info[0].Pasportn.ToString()!;
                    LabelPasports.Text = info[0].Pasports.ToString()!;
                    LabelBethday.Text = info[0].Bethday.ToString()!;
                    LabelWorck.Text = info[0].Worck!;
                    LabelStrahovcompani.Text = info[0].Strahovcompani!;
                    LabelDatagetmeadcart.Text = info[0].Datagetmeadcart.ToString()!;
                    LabelDatalastvisit.Text = info[0].Datalastvisit.ToString()!;
                    LabelDatanextvisit.Text = info[0].Datanextvisit.ToString()!;
                    LabelNumberpolis.Text = info[0].Numberpolis.ToString()!;
                    LabelDatafinishpolis.Text = info[0].Datafinishpolis.ToString()!;
                    LabelId.Text = info[0].Id.ToString()!;   
                }
            }
        }
    }
}


public class FullInfo
{
    public int? Id { get; set; }

    public DateTime? Datafinishpolis { get; set; }

    public int? Numberpolis { get; set; }

    public DateTime? Datanextvisit { get; set; }

    public DateTime? Datalastvisit { get; set; }

    public DateTime? Datagetmeadcart { get; set; }

    public string? Strahovcompani { get; set; }

    public string? Worck { get; set; }

    public DateTime? Bethday { get; set; }

    public int? Pasports { get; set; }

    public int? Pasportn { get; set; }

    public string? Foto { get; set; }

    public string? Emailuser { get; set; }

    public string? Adres { get; set; }

    public string? Phone { get; set; }

    public string? Nameuser { get; set; }

    public string? Namegender { get; set; }

    public int? Numbermedcart { get; set; }
}