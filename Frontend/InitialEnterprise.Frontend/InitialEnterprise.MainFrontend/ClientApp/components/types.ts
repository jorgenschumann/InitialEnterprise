export class DataTransferObject  { 
    public UserId: string = '';
}

export class DomainEventDto implements DataTransferObject {
    public Id: string = '';
    public AggregateRootId: string = '';
    public CommandId: string = '';
    public Version: number  | undefined;
    public UserId: string = '';
    public Source: string = '';
    public TimeStamp: Date | undefined;
}