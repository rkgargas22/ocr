namespace Tmf.Ocr.Core.Constants;

public static class ValidationMessages
{
    public const string GeneralValidationErrorMessage = "One or more erros in request data validation.";
    public const string ErrorInRequest = "Error in request.";

    #region header
    public const string BpNoHeader = "Please add BpNo in request header.";
    public const string UserTypeHeader = "Please add UserType in request header.";
    #endregion

    #region Content/Type
    public const string ApplicationJson = "application/json";
    #endregion

    public const string GroupId = "Please Enter valid Group Id";
    public const string TaskId = "Please Enter valid Task Id";
    public const string Data = "Data cannot be null";

    public const string Consent = "Please provide with consent";
    public const string Document1 = "Please provide valid document 1";
    public const string Document2 = "Please provide valid document 2";

    public const string DocType = "Please provide valid DocType";
    public const string AdvancedFeatures = "Please provide valid Advanced Features";

    public const string DetectDocSide = "Please provide valid Detect Doc Side";

    public const string RequestId = "Please enter valid Request Id";
    public const string RequestType = "Please enter valid Request Type";
}
