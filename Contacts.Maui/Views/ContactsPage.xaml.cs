
using Contacts.Maui.Models;
using System.Collections.ObjectModel;
using Contact = Contacts.Maui.Models.Contact;

namespace Contacts.Maui.Views;

public partial class ContactsPage : ContentPage
{
	public ContactsPage()
	{
		InitializeComponent();

        
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadItems();
        
    }



    private async void listContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    { if (listContacts.SelectedItem != null) { 
            await Shell.Current.GoToAsync($"{nameof(EditContactsPage)}?ID={((Contact)listContacts.SelectedItem).ID}"); 
        }
        
    }

    private void listContacts_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        listContacts.SelectedItem = null;
    }

    private void AddContacts_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"{nameof(AddContactsPage)}");
    }

    private void DeleteBtn_Clicked(object sender, EventArgs e)
    {
        var menuItem = sender as MenuItem;
        var contact = menuItem.CommandParameter as Contact;
        ContactsRepository.DeleteContact(contact.ID);
        LoadItems();
    }
    private void LoadItems()
    {
        var contacts = new ObservableCollection<Contact>(ContactsRepository.GetContacts());

        listContacts.ItemsSource = contacts;
    }

    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        var contacts = new ObservableCollection<Contact>(ContactsRepository.SearchContacts(((SearchBar)sender).Text));

        listContacts.ItemsSource = contacts;
    }
}