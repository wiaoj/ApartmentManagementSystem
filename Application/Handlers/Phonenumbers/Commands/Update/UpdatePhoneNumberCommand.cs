using Application.Handlers.Phonenumbers.Dtos.Commands;
using MediatR;

namespace Application.Handlers.Phonenumbers.Commands.Update;

public class UpdatePhoneNumberCommand : IRequest<UpdatedPhoneNumberDto> {
	public Guid Id { get; set; }

	internal class UpdateCommandHandler : IRequestHandler<UpdatePhoneNumberCommand, UpdatedPhoneNumberDto> {
		public Task<UpdatedPhoneNumberDto> Handle(UpdatePhoneNumberCommand request, CancellationToken cancellationToken) {
			throw new NotImplementedException();
		}
	}
}