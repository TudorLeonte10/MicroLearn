import { useEffect, useState } from "react";
import axios from "axios";

export default function useAuth(){
    const [loading, setLoading] = useState(true);
    const [isAuthenticated, setIsAuthenticated] = useState(false);

    useEffect(() => {
        const checkAuth = async () => {
            const token = localStorage.getItem("token");
            if (!token) {
                setIsAuthenticated(false);
                setLoading(false);
                return;
            }

            try {
                const resp = await axios.get("http://localhost:5114/api/auth/me", {
                    headers: {
                        Authorization: `Bearer ${token}`,
                    },
                });
                
                if(resp.status === 200){
                    setIsAuthenticated(true);
                }
                else{
                    setIsAuthenticated(false);
                    localStorage.removeItem("token");
                }
            } catch (err) {
                setIsAuthenticated(false);
                localStorage.removeItem("token");
            }
            finally {
                setLoading(false);
            }
        };
        checkAuth();
    }, []);

    return { loading, isAuthenticated };
}