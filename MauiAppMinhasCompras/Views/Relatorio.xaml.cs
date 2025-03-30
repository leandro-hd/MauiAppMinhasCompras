using MauiAppMinhasCompras.Helpers;
using MauiAppMinhasCompras.Models;
using System.Collections.ObjectModel;

namespace MauiAppMinhasCompras.Views;

public partial class Relatorio : ContentPage
{
    ObservableCollection<CategoriaTotal> lista = new ObservableCollection<CategoriaTotal>();

    public Relatorio()
    {
        InitializeComponent();
				lst_relatorios.ItemsSource = lista; 
    }

    protected async override void OnAppearing()
    {
        try
        {
            lista.Clear();

            List<CategoriaTotal> tmp = await App.Db.GetTotalPorCategoria();

            tmp.ForEach(i => lista.Add(i));
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", ex.Message, "OK");
        }
    }
}
