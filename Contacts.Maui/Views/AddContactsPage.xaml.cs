using Contacts.Maui.Models;
using Contact = Contacts.Maui.Models.Contact;

namespace Contacts.Maui.Views;

public partial class AddContactsPage : ContentPage
{
    
    public AddContactsPage()
    {
        InitializeComponent();
    }
    private void BtnGoback_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(ContactsPage));

    }

    private void contactsAdd_OnSave(object sender, EventArgs e)
    {
        ContactsRepository.AddContact(new Contact {
            name = contactsAdd.name,
            email = contactsAdd.email,
            phone = contactsAdd.phone,
            address = contactsAdd.address,
        });
        Shell.Current.GoToAsync("..");

    }

    private void contactsAdd_OnError(object sender, string e)
    {
        DisplayAlert("Error", e, "Ok");
    }
}