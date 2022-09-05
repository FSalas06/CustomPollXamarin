using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using CustomPollXamarin.Models;
using MvvmHelpers;
using MvvmHelpers.Commands;

namespace CustomPollXamarin.ViewModels
{
    public class ViewModelTest : BaseViewModel
    {
        private ObservableCollection<QuestAnsware> _questionaryList;
        private int PollStep;
        private ObjInit _objInit;

        public ICommand NextCommand { private set; get; }
        public ICommand BackCommand { private set; get; }

        private List<QuestAnsware> QuestionaryListAux { get; set; }

        public ObservableCollection<QuestAnsware> QuestionaryList
        {
            get { return _questionaryList; }
            set
            {
                SetProperty(ref _questionaryList, value);
            }
        }

        public ObjInit ObjInit
        {
            get { return _objInit; }
            set
            {
                SetProperty(ref _objInit, value);
            }
        }

        public ViewModelTest(ObjInit objInit)
        {
            InitCommands();
            ObjInit = objInit;
            InitData();
        }

        private void InitData()
        {
            QuestionaryListAux = new List<QuestAnsware>();
            PollStep = 1;
            CreatePoll();
        }

        private void CreatePoll()
        {
            if (ObjInit.EntryCount > 0)
            {
                for (int i = 0; i <= ObjInit.EntryCount; i++)
                {
                    var QuestAns = new QuestAnsware
                    {
                        Step = 1,
                        Answare = "Entry Answare",
                        Quest = "Entry Question",
                        Type = 1,
                    };
                    QuestionaryListAux.Add(QuestAns);
                }
            }

            if (ObjInit.PickeCount > 0)
            {
                for (int i = 1; i <= ObjInit.PickeCount; i++)
                {
                    var QuestAns = new QuestAnsware
                    {
                        Step = 2,
                        Quest = "Picker Question",
                        AnswareList = new List<string>
                         {
                             "Picker Answare 1",
                             "Picker Answare 2",
                             "Picker Answare 3",
                         },
                        Type = 2,
                    };
                    QuestionaryListAux.Add(QuestAns);
                }
            }

            if (ObjInit.CheckCount > 0)
            {
                for (int i = 1; i <= ObjInit.CheckCount; i++)
                {
                    var QuestAns = new QuestAnsware
                    {
                        Step = 3,
                        Answare = "Entry Answare",
                        Quest = "Entry Question",
                        Type = 4,
                    };
                    QuestionaryListAux.Add(QuestAns);
                }
            }

            var init = QuestionaryListAux.Where(q => q.Step == PollStep);
            QuestionaryList = new ObservableCollection<QuestAnsware>(init);
            var x = QuestionaryList.GroupBy(a => a.Step);
        }

        private void InitCommands()
        {
            NextCommand = new Command(NextCommandExecute);
            BackCommand = new Command(BackCommandExecute);
        }

        private void BackCommandExecute()
        {
            if (PollStep > 1)
            {
                PollStep--;
                var next = QuestionaryListAux.Where(q => q.Step == PollStep);
                QuestionaryList = new ObservableCollection<QuestAnsware>(next);
            }
        }

        private void NextCommandExecute()
        {
            var getMax = QuestionaryListAux.Max(q => q.Step);
            if (PollStep < getMax)
            {
                PollStep++;
                var next = QuestionaryListAux.Where(q => q.Step == PollStep);
                QuestionaryList = new ObservableCollection<QuestAnsware>(next);
            }
        }

    }
}
