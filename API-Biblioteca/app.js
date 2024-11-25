import express from "express";
import morgan from 'morgan'
import { DEFAULT_API_URI } from "./config.js";
import AuthRoutes from "./src/routes/user.routes.js"
import SociosRoutes from "./src/routes/socios.routes.js"
import BibliotecasRoutes from "./src/routes/bibliotecas.routes.js";

const app = express() 

app.use(morgan("dev"))
app.use(express.json())

app.use(DEFAULT_API_URI, AuthRoutes)
app.use(DEFAULT_API_URI, SociosRoutes)
app.use(DEFAULT_API_URI, BibliotecasRoutes)

export default app 