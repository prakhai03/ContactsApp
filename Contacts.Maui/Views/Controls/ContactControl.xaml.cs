namespace Contacts.Maui.Views.Controls;

public partial class ContactControl : ContentView
{
    public event EventHandler<String> OnError;
    public event EventHandler<EventArgs> OnSave;
    public event EventHandler<EventArgs> OnCancel;
    public ContactControl()
	{
		InitializeComponent();
	}

	public String name
	{
		get
		{
			return entryName.Text;
		}
		set
		{
			entryName.Text = value;
		}
	}

    public String email
    {
        get
        {
            return entryEmail.Text;
        }
        set
        {
            entryEmail.Text = value;
        }
    }

    public String address
    {
        get
        {
            return entryAddress.Text;
        }
        set
        {
            entryAddress.Text = value;
        }
    }

    public String phone
    {
        get
        {
            return entryPhone.Text;
        }
        set
        {
            entryPhone.Text = value;
        }
    }

    private void Save_Clicked(object sender, EventArgs e)
    {
        if (NameValidator.IsNotValid)
        {
            OnError?.Invoke(sender, "Name Should not be empty");
            return;
        }

        if (EmailValidator.IsNotValid)
        {
            foreach (var error in EmailValidator.Errors)
            {
                OnError?.Invoke(sender, error.ToString());
            }
            return;
        }

        OnSave?.Invoke(sender, e);

    }

    private void Cancel_Clicked(object sender, EventArgs e)
    {
        OnCancel?.Invoke(sender, e);
    }
}