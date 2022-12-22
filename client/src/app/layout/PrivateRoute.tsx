import { Navigate, Outlet, useLocation, useParams } from "react-router-dom";
import { useAppSelector } from "../store/configureStore";


export const PrivateRoute = () => {
  const location = useLocation();
  const { user } = useAppSelector((state) => state.account);
  const { company_id } = useParams<{ company_id: string }>();

  return !user ? (
    <Navigate replace to={`/${company_id}/login`} state={{ from: location }} />
  ) : (
    <Outlet />
  );
};