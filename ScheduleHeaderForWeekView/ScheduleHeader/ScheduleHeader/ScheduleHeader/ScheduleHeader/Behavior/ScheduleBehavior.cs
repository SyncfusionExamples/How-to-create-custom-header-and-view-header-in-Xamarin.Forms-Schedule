using Syncfusion.SfSchedule.XForms;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ScheduleHeader
{
    internal class ScheduleBehavior : Behavior<ContentPage>
    {
        private SfSchedule schedule;
        private Label Header;
        private Grid sunday, monday, tuesday, wednesday, thursday, friday, saturday;

        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            schedule = bindable.FindByName<SfSchedule>("schedule");
            Header = bindable.FindByName<Label>("Header");
            sunday = bindable.FindByName<Grid>("Sunday");
            monday = bindable.FindByName<Grid>("Monday");
            tuesday = bindable.FindByName<Grid>("Tuesday");
            wednesday = bindable.FindByName<Grid>("Wednesday");
            thursday = bindable.FindByName<Grid>("Thursday");
            friday = bindable.FindByName<Grid>("Friday");
            saturday = bindable.FindByName<Grid>("Saturday");
            schedule.VisibleDatesChangedEvent += Schedule_VisibleDatesChangedEvent;
        }

        private void Schedule_VisibleDatesChangedEvent(object sender, VisibleDatesChangedEventArgs e)
        {
            Header.Text = e.visibleDates[e.visibleDates.Count / 2].ToString("MMMM yyyy");
            if (schedule.ScheduleView == ScheduleView.WeekView)
            {
                sunday.FindByName<Label>("SundayDateLabel").Text = e.visibleDates[0].Date.ToString("dd");
                monday.FindByName<Label>("MondayDateLabel").Text = e.visibleDates[1].Date.ToString("dd");
                tuesday.FindByName<Label>("TuesdayDateLabel").Text = e.visibleDates[2].Date.ToString("dd");
                wednesday.FindByName<Label>("WednesdayDateLabel").Text = e.visibleDates[3].Date.ToString("dd");
                thursday.FindByName<Label>("ThursdayDateLabel").Text = e.visibleDates[4].Date.ToString("dd");
                friday.FindByName<Label>("FridayDateLabel").Text = e.visibleDates[5].Date.ToString("dd");
                saturday.FindByName<Label>("SaturdayDateLabel").Text = e.visibleDates[6].Date.ToString("dd");
            }
        }
    }
}
