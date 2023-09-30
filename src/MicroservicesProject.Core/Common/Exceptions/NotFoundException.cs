namespace MicroservicesProject.Core.Common.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string fieldName, object fieldData)
            : base($"There is no {fieldData} value for entity {fieldName}")
        {
        }
    }
}
