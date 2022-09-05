using System;
using CustomPollXamarin.Enum;
using CustomPollXamarin.Models;
using Xamarin.Forms;

namespace CustomPollXamarin.Utils.Templates
{
    public class PollTemplateSelector : DataTemplateSelector
    {
        public DataTemplate QuestEntryTemplate { get; set; }
        public DataTemplate QuestPickerTemplate { get; set; }
        public DataTemplate QuestRadioTemplate { get; set; }

        public PollTemplateSelector()
        {
            QuestEntryTemplate = (DataTemplate)Application.Current.Resources["QuestEntryTemplate"];
            QuestPickerTemplate = (DataTemplate)Application.Current.Resources["QuestPickerTemplate"];
            QuestRadioTemplate = (DataTemplate)Application.Current.Resources["QuestRadioTemplate"];
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var quest = (QuestAnsware)item;
            PollEnum poll = (PollEnum)quest.Type;
            if(poll == PollEnum.Entry)
            {
                return QuestEntryTemplate;
            }
            if (poll == PollEnum.Picker)
            {
                return QuestPickerTemplate;
            }
            if (poll == PollEnum.Radio)
            {
                return QuestPickerTemplate;
            }
            return QuestEntryTemplate;

        }
    }
}

