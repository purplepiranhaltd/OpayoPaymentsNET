using OpayoPaymentsNet.Domain.Entities.Instructions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpayoPaymentsNet.Domain.Builders.Instructions
{
    public static class OpayoInstructionRequestBuilderExtensions
    {
        /// <summary>
        /// The void instruction type allows you to void a successful transaction up until midnight on the day it is processed.
        /// Voiding will cancel the payment and prevent funds being transferred from the customer account.
        /// Voids are non-reversible.
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IOpayoInstructionRequestBuilderWithInstructionTypeVoidAbortCancel AsVoidInstruction(this INewBuilder<OpayoInstructionRequest> builder)
        {
            builder.Request.InstructionType = OpayoInstructionType.Void;
            return (IOpayoInstructionRequestBuilderWithInstructionTypeVoidAbortCancel)builder;
        }

        /// <summary>
        /// If you are unable to fulfil the order, the abort instruction type allows you to abort a deferred transaction
        /// and the customer will never be charged.
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IOpayoInstructionRequestBuilderWithInstructionTypeVoidAbortCancel AsAbortInstruction(this INewBuilder<OpayoInstructionRequest> builder)
        {
            builder.Request.InstructionType = OpayoInstructionType.Abort;
            return (IOpayoInstructionRequestBuilderWithInstructionTypeVoidAbortCancel)builder;
        }

        /// <summary>
        /// Cancels an Authenticate transaction.
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IOpayoInstructionRequestBuilderWithInstructionTypeVoidAbortCancel AsCancelInstruction(this INewBuilder<OpayoInstructionRequest> builder)
        {
            builder.Request.InstructionType = OpayoInstructionType.Cancel;
            return (IOpayoInstructionRequestBuilderWithInstructionTypeVoidAbortCancel)builder;
        }

        /// <summary>
        /// Deferred transactions are not sent to the bank for completion until you Release them using the release instruction.
        /// You can release only once and only for an amount up to and including the amount of the original Deferred transaction.​​​
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IOpayoInstructionRequestBuilderWithInstructionTypeRelease AsReleaseInstruction(this INewBuilder<OpayoInstructionRequest> builder)
        {
            builder.Request.InstructionType = OpayoInstructionType.Release;
            return (IOpayoInstructionRequestBuilderWithInstructionTypeRelease)builder;
        }

        /// <summary>
        /// The amount property is compulsory for a 'release' instruction after a 'Deferred' transaction.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="amount">The amount charged to the customer in the smallest currency unit. (e.g 100 pence to charge £1.00, or 1 to charge ¥1 (0-decimal currency).</param>
        /// <returns></returns>
        public static IOpayoInstructionRequestBuilderWithInstructionTypeReleaseAndAmount WithRequiredAmount(this IOpayoInstructionRequestBuilderWithInstructionTypeRelease builder, int amount)
        {
            builder.Request.Amount = amount;
            return (IOpayoInstructionRequestBuilderWithInstructionTypeReleaseAndAmount)builder;
        }
    }
}
