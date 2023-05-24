type Props = {
    title: string;
    onClick: () => void;
}

export default function Button({title, onClick}: Props) {
    return (
        <button onClick={e => {e.preventDefault(); onClick()}}>
            {title}
        </button>
    );
}
