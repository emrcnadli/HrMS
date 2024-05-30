using AutoMapper;
using Hr_Management_System.Data;
using Hr_Management_System.Models.Entities;
using MediatR;

namespace Hr_Management_System.Features.Person.Coımmand.EditPerson
{
    public class EditPersonCommand : IRequest<Models.Entities.Person>
    {
        public Models.Entities.Person Person { get; set; }
    }
}