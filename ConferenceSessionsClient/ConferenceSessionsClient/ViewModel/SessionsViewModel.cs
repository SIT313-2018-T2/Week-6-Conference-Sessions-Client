using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using ConferenceSessionsClient.Data;
using ConferenceSessionsClient.Model;

namespace ConferenceSessionsClient.ViewModel
{
    public class SessionsViewModel : INotifyPropertyChanged
    {
        SessionsManager sessionsManager = new SessionsManager();
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Session> _sessionslist;
        public ObservableCollection<Session> SessionsList
        {
            get { return _sessionslist; }
            set
            {
                _sessionslist = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("SessionsList"));
                }
            }
        }
        public async Task FetchDataAsync()
        {
            var list = await sessionsManager.FetchSessionsAsync();
            SessionsList = new ObservableCollection<Session>(list);
        }
        public SessionsViewModel()
        {
            FetchDataAsync();
        }
    }
}
