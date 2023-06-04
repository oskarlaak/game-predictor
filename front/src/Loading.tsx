// import { useEffect, useContext, useState } from "react";
// import IErrorDTO from "./dto/IErrorDTO";
// import { handleRequest } from "./helpers/helpers";
// import { ErrorContext } from "./App";

// type Props<T extends object> = {
//     request: () => Promise<T | IErrorDTO | undefined>;
//     setter: (previous: T) => void;
// };

// export default function Loading<T extends object>({request, setter}: Props<T>): JSX.Element {

//     const {error, setError} = useContext(ErrorContext);

//     const [loading, setLoading] = useState<boolean>(true);

//     useEffect(() => {
//         handleRequest<T>(request, setError, setter);
//         setLoading(false);
//     }, []);

//     return <>{loading ? "Loading..." : ""}</>;
// }
export {};
