using Contacts.Maui.Models;
using System.Collections.ObjectModel;
using Contact = Contacts.Maui.Models.Contact;

namespace Contacts.Maui.Views;


[QueryProperty(nameof(ID),"ID")]
public partial class EditContactsPage : ContentPage
{
    private Contact contact;
	public EditContactsPage()
	{
        InitializeComponent();
	}
    private void BtnGoback1_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }

    public string ID
    {
        set
        {
            contact = ContactsRepository.GetContactByID(int.Parse(value));
            if (contact != null) {
                contactControl.name = contact.name;
                contactControl.email = contact.email;
                contactControl.address = contact.address;
                contactControl.phone = contact.phone;

            }
        }
    }

    private void Update_Clicked(object sender, EventArgs e)
    {
        
        contact.name = contactControl.name;
        contact.email = contactControl.email;
        contact.address =  contactControl.address;
        contact.phone = contactControl.phone;

        ContactsRepository.UpdateContact(contact.ID, contact);
        Shell.Current.GoToAsync("..");

    }

    private void control_OnError(object sender, string e)
    {
        DisplayAlert("Error", e, "Ok");
    }
}