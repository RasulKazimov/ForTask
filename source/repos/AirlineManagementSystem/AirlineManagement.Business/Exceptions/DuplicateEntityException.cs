using System;
using System.Collections.Generic;
using System.Text;
namespace AirlineManagement.Application.Exceptions;

public class DuplicateEntityException : BusinessException
{
    public DuplicateEntityException(string entityName, string propertyName, object value)
        : base($"{entityName} üçün '{propertyName}' = '{value}' artıq bazada mövcuddur!")
    { }
}