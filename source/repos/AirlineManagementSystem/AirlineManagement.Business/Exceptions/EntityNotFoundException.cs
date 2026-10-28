using System;
using System.Collections.Generic;
using System.Text;
namespace AirlineManagement.Application.Exceptions;

public class EntityNotFoundException : BusinessException
{
    public EntityNotFoundException(string entityName, object id)
        : base($"{entityName} tapılmadı (ID: {id}).")
    { }
}