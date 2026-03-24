using Smraa_AlYaman.Common.Errors;

namespace Smraa_AlYaman.Common.ResultOf
{
    public interface IResultOf<TValue>
    {
        TValue Value { get; }
    }

    public interface IResultOf
    {
        List<Error>? Errors { get; }
        bool IsFailure { get; }
    }
}
