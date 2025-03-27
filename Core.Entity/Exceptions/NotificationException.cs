using System.ComponentModel;
using Core.Entity.Helpers;

namespace Core.Entity.Exceptions;

public class NotificationException : Exception
{
   public string errMsg { get; set;}
   public TypeExceptions typeException { get; set; }

   public NotificationException(TypeExceptions exceptionType)
   {
      new ArgumentNullException(BaseExceptionsMessage.PrintException(exceptionType));
   }
}