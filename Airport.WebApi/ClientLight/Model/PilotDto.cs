namespace ClientLight.Model
{
    using System;

    using ClientLight.Interfaces;

    using GalaSoft.MvvmLight;

    public class PilotDto : ViewModelBase, IEntity<int>
    {
        public PilotDto() { }

        private int _id;
        public int Id
        {
            get { return _id; }
            set {_id = value; }
        }

        private Age _experienceAge;
        public Age ExperienceAge
        {
            get { return _experienceAge; }
            set { _experienceAge = value; }
        }

        // Offset
        private DateTime _dateOfBirth;
        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; }
        }

        private string _familyName;
        public string FamilyName
        {
            get { return _familyName; }
            set { _familyName = value; }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private Age _age;
        public Age Age
        {
            get { return _age; }
            set { _age = value; }
        }
    }
}
