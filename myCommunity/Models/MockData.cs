using System;

using Xamarin.Forms;
using System.Collections.Generic;

namespace myCommunity
{
	public static class MockData
	{

		static List<CommunityEvent> mockData = new List<CommunityEvent>(); // create a list of mock event data

		static MockData() {
			mockData.Add (
				new CommunityEvent {
				EventDate = "13 May, 2015",
				EventTime = "1800 - 2100",
				Description = "This session will be about implementing (AngularJS, NodeJS, JavaScript, HTML5, CSS3, Jasmine, …) and taking the Product features/requirements further.",
				Topic = "ERNI Faces Hack Session",
				Type = "Hack Session",
				Location = "Zurich",
				Responsible = "Stefan Odermatt",
				IsFood = false,
				BookableTime = 0});
						
			mockData.Add ( new CommunityEvent {
				EventDate = "19 May, 2015",
				EventTime = "1730 - 2030",
				Description = "Embedded C++ developers, ERNI Employees interested in \ngetting hands on programming\nlearning about new technologies\nunit testing",
				Topic = "Embedded C++ Hack Session",
				Type = "Hack Session",
				Location = "Bern",
				Responsible = "Dieter Niklaus",
				IsFood = true,
				BookableTime = 0
			});
			mockData.Add ( new CommunityEvent {
				EventDate = "20 May, 2015",
				EventTime = "1800 - 2030",
				Description = "Continuous Delivery using Jenkins, Groovy and Docker",
				Topic = "Continuous Delivery",
				Type = "Swiss post@ ERNI Community",
				Location = "Bern",
				Responsible = "Jazz Kang",
				IsFood = true,
				BookableTime = 0
			});
			mockData.Add (new CommunityEvent {
				EventDate = "10 June, 2015",
				EventTime = "1830 - 2130",
				Description = "Continuous Delivery using Jenkins, Groovy and DockerFor developers who want to be involved in the Ideas Board App for Android and HTML, which was started on EDD 1.",
				Topic = "Ideas Board ",
				Type = "Hack Session",
				Location = "Zurich",
				Responsible = "Angus Long",
				IsFood = true,
				BookableTime = 0
			});
			mockData.Add ( new CommunityEvent {
				EventDate = "17 June, 2015",
				EventTime = "1800 - 2000",
				Description = "Project Managers, PMO, People interested in those topics",
				Topic = "Project Risk Management",
				Type = "community@work",
				Location = "Zurich",
				Responsible = "Ricco Innocente",
				IsFood = true,
				BookableTime = 2
			});
		}

			public static List<CommunityEvent> getMockData() {
			return mockData;
		}
			
	}
}


