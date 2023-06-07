import IErrorDTO from "../../dto/IErrorDTO";
import Button from "./Button";

type Props<TDto, TResponse> = {
    buttonTitle: string;
    onSubmitRequest: (dto: TDto) => Promise<TResponse | IErrorDTO | undefined>;
    onSuccess: (response: TResponse) => void;
    dto: TDto;
    children: JSX.Element | JSX.Element[];
};

export default function FormWithButton<TDto, TResponse extends object>({
    buttonTitle,
    onSubmitRequest,
    onSuccess,
    dto,
    children
}: Props<TDto, TResponse>): JSX.Element {
    return <>
        <form>
            {children}
            <Button
                title={buttonTitle}
                onClickRequest={() => onSubmitRequest(dto)}
                onSuccess={onSuccess}
            />
        </form>
    </>;
}
