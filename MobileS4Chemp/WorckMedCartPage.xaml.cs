using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MobileS4Chemp;

public partial class WorckMedCartPage : ContentPage
{
    private List<ReseptListModel> _reseptList = new List<ReseptListModel>();
    public WorckMedCartPage()
    {
        InitializeComponent();
        LoadFilters();
    }


    private async void LoadFilters()
    {
        using (var client = new HttpClient())
        {
            HttpResponseMessage responseMessage = await client.GetAsync("http://localhost:5298/api/IssledTipe/GetIssledTipe");
            string context = await responseMessage.Content.ReadAsStringAsync();
            List<IssledTipeModel> tipe = JsonConvert.DeserializeObject<List<IssledTipeModel>>(context)!.ToList();
            PickerIssled.ItemsSource = tipe.Select(x => new
            {
                NameIssled = x.Nameissled
            }).ToList();
        }
    }

    private void AddFromListResept(object? sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(PriporatEntry.Text) && !string.IsNullOrEmpty(DozaEntry.Text) && !string.IsNullOrEmpty(FormatEntry.Text))
        {
            ReseptListModel reseptListModel = new ReseptListModel();
            reseptListModel.Doza = DozaEntry.Text;
            reseptListModel.NamePriporat = PriporatEntry.Text;
            reseptListModel.Format = FormatEntry.Text;
            _reseptList.Add(reseptListModel);
            ListViewResept.ItemsSource = _reseptList.Select(x => new
            {
                LabelNamePreporat = "Припорат:" + x.NamePriporat,
                LabelDoza = "Дозировка:" + x.Doza,
                LabelFormat = "Формат:" + x.Format
            }).ToList();
        }
    }

    private void SaveButton(object? sender, EventArgs e)
    {
        
    }
}


public class IssledTipeModel
{
    public int Id { get; set; }
    public string Nameissled { get; set; }
}

public class ReseptListModel
{
    public string? NamePriporat { get; set; }
    public string? Doza { get; set; }
    public string? Format { get; set; }
}