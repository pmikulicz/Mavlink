using Mavlink.Messages.Configuration;

namespace Mavlink.Messages.Dialects.Ardupilot
{
    public sealed class ParamRequestReadMessage : ArdupilotMessage
    {
        public override MessageId Id => new ArdupilotMessageId(ArdupilotId.ParamRequestRead);

        /// <summary>
        /// Gets or sets parameter index. Send -1 to use the param ID field as identifier (else the param id will be ignored)
        /// </summary>
        public short ParamIndex { get; set; }

        /// <summary>
        /// Gets or sets system id
        /// </summary>
        public byte TargetSystem { get; set; }

        /// <summary>
        /// Gets or sets component id
        /// </summary>
        public byte TargetComponent { get; set; }

        /// <summary>
        /// Gets or sets onboard parameter id, terminated by NULL.
        /// If the length is less than 16 human-readable chars and WITHOUT null termination (NULL) byte
        /// if the length is exactly 16 chars - applications have to provide 16+1 bytes storage if the ID is stored as string
        /// </summary>
        public char[] ParamId { get; set; }

        
    }
}