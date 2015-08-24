using System;
using GalaSoft.MvvmLight;
using myCommunity.Models;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;
using Acr.UserDialogs;
using myCommunity.Services;
using myCommunity.Views.XAML;

namespace myCommunity
{
	public class DetailsViewModel : ViewModelBase
	{
		private CommunityEvent m_CommunityEvent;
		private string m_PictureUrl;
		private string m_Title;
		private string m_EventDate;
		private string m_Location;
		private string m_Type;
		private List<Person> m_Attendees;
		private RelayCommand m_SignUpClicked;
		private const string USERNAME_KEY = "username";

		public DetailsViewModel ()
		{
		}



		public string PictureUrl { get { return m_PictureUrl; } set { m_PictureUrl = value; RaisePropertyChanged ("PictureUrl");}}
		public string Title { get { return m_Title; } set { m_Title = value; RaisePropertyChanged ("Title");}}
		public string EventDate { get { return m_EventDate; } set { m_EventDate = value; RaisePropertyChanged ("EventDate");}}
		public string Location { get { return m_Location; } set { m_Location = value; RaisePropertyChanged ("Location");}}
		public string Type { get { return m_Type; } set { m_Type = value; RaisePropertyChanged ("Type");}}
		public List<Person> Attendees { get { return m_Attendees; } set { m_Attendees = value; RaisePropertyChanged ("Attendees");}}

		public CommunityEvent CommunityEvent {
			set 
			{
				m_CommunityEvent = value;
				PictureUrl = value.PictureUrl;
				Title = value.Title;
				EventDate = value.EventDate;
				Location = value.Location;
				Type = value.Type;
				Attendees = value.Attendees;
			}
		}

		public RelayCommand SignUp_Clicked
		{
			get
			{ 
				return m_SignUpClicked ?? new RelayCommand (SignUpClicked); 
			}
		}

		protected void SignUpClicked()
		{
			string username = string.Empty;

			if (Application.Current.Properties.ContainsKey (USERNAME_KEY))
				username = Application.Current.Properties [USERNAME_KEY] as string;

			if (string.IsNullOrEmpty (username) && m_CommunityEvent != null) {


				var promptConfig = new PromptConfig {
					CancelText = "Cancel",
					IsCancellable = true,
					OkText = "OK",
					Message = "this will be saved to the application preferences which will be used on your next sign up",
					Title = "Signup Name",
					InputType = InputType.Default,
					Placeholder = "Your Name",
					OnResult = this.OnSignUp
				};
				UserDialogs.Instance.Prompt (promptConfig);

			} else {
				this.SignUp (username);
			}
		}

		private void OnSignUp(PromptResult result)
		{

			if (result.Ok)
			{
				Application.Current.Properties.Add("username", result.Text);
				this.SignUp(result.Text);
			}
		}

		private async void SignUp(string username)
		{
			if (m_CommunityEvent != null)
			{
				using (UserDialogs.Instance.Loading("Signing Up..."))
				{
					var webservice = new RestClient();
					var retval = await webservice.EventSignUpAsync(m_CommunityEvent.ID, username);
					if (retval.Code == "Created")
					{
						UserDialogs.Instance.Alert("Succesfully signed up in the event", "Signed Up", "OK");

						if (!m_CommunityEvent.Participants.Contains(username))
						{
							m_CommunityEvent.Participants.Add(username);
							m_CommunityEvent.Attendees.Add (new Person{ Name = username });
							RaisePropertyChanged ("Attendees");
						}

						MessagingCenter.Send<DetailsViewModel>(this, "RefreshFromSignup");

					}
				}
			}
		}
	}
}