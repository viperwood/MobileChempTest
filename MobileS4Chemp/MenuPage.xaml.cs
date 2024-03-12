using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileS4Chemp;

public partial class MenuPage : ContentPage
{
    public MenuPage()
    {
        InitializeComponent();
    }

    private async void WorckMedCartButton(object? sender, EventArgs e)
    {
        WorckMedCartPage worckMedCartPage = new WorckMedCartPage();
        await Navigation.PushAsync(worckMedCartPage);
    }

    private async void InfoButton(object? sender, EventArgs e)
    {
        InfoPatientPage infoPatientPage = new InfoPatientPage();
        await Navigation.PushAsync(infoPatientPage);
    }
}