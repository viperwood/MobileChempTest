using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json.Serialization;
using Microsoft.Maui.Controls;
using Newtonsoft.Json;

namespace MobileS4Chemp;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
    }

    private async void LoginButton(object? sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(EntryLogin.Text))
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage responseMessage = await client.GetAsync($"http://10.0.2.2:5298/api/LoginDesctop/GetLoginDoctor?login={EntryLogin.Text}");
                string content = await responseMessage.Content.ReadAsStringAsync();
                List<string> info = JsonConvert.DeserializeObject<List<string>>(content)!.ToList();
                if (info.Count != 0 || info.Count != null)
                {
                    MenuPage menuPage = new MenuPage();
                    await Navigation.PushAsync(menuPage);
                }
            }
        }
    }
}