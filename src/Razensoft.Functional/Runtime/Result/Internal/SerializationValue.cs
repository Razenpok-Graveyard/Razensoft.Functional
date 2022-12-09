namespace Razensoft.Functional
{
    internal class SerializationValue<E>
    {
        public bool IsFailure { get; }
        public E Error { get; }

        internal SerializationValue(bool isFailure, E error)
        {
            IsFailure = isFailure;
            Error = error;
        }
    }
}
