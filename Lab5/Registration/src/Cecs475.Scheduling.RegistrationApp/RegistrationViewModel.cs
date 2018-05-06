using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cecs475.Scheduling.RegistrationApp
{
    public class SemesterTermDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString() { return Name; }
    }

    public class CourseSectionDto
    {
        public int Id { get; set; }
        public int SemesterTermId { get; set; }
        public CatalogCourseDto CatalogCourse { get; set; }
        public int SectionNumber { get; set; }
        public override string ToString()
        {
            //Ex. "CECS 174-01"
            return CatalogCourse.DepartmentName + " " + CatalogCourse.CourseNumber
               + "-" + SectionNumber;
        }
    }

    public class CatalogCourseDto
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string CourseNumber { get; set; }
        public int[] PrerequisiteCourseIds { get; set; }
    }
    public class RegistrationViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// A URL path to the registration web service.
        /// </summary>
        public string ApiUrl { get; set; }
        /// <summary>
        /// The full name of the student who is registering.
        /// </summary>
        public string FullName { get; set; }

        IEnumerable<SemesterTermDto> mSemesterTerm;
        public IEnumerable<SemesterTermDto> SemesterTerm
        {
            get { return mSemesterTerm; }
            set
            {
                mSemesterTerm = value;
                OnPropertyChanged(nameof(SemesterTerm));
            }
        }
        IEnumerable<CourseSectionDto> mCourseSection;
        public IEnumerable<CourseSectionDto> CourseSection
        {
            get { return mCourseSection; }
            set
            {
                mCourseSection = value;
                OnPropertyChanged(nameof(CourseSection));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
