using CH03Library.MAIN;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH03Library.zVALIDATOR
{
    public class MemberValidation : AbstractValidator<MemberModel>
    {
        public MemberValidation()
        {
            RuleFor(p => p.Member_Name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Name cannot be Empty")
                .Length(2, 60).WithMessage("This Name is InValid ")
                .Must(isnamevalid).WithMessage("The name has insvalid Characters");
            
            RuleFor(p => p.Member_FName)`
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Name cannot be Empty")
                .Length(2, 60).WithMessage("This Name is InValid ")
                .Must(isnamevalid).WithMessage("The name has insvalid Characters");

            RuleFor(p => p.Member_Gender)
                .NotEmpty().WithMessage("Name cannot be Empty");
            
            RuleFor(p => p.Member_DOB)
                .NotEmpty().WithMessage("Name cannot be Empty")
                .Must(isDOBValid).WithMessage("Dateofbirth is Invalid");


        }

        protected bool isnamevalid(string name) 
        {
            name = name.Replace(" ", "");
            name = name.Replace("-", "");
            name = name.Replace(".", "");

            return name.All(char.IsLetter);
        }

        protected bool isDOBValid(DateTime date) 
        {
            int PID = date.Year;

            if (PID < 1900)
            {
                return false;
            }

            return true;
        }
    }


   
}
