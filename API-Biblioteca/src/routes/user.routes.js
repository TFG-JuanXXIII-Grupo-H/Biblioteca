import {Router} from 'express'
import {register, login} from '../controllers/user.controller.js'
import {validateSchema} from '../middlewares/validate.middleware.js'
import {loginSchema, registerSchema} from "../schemas/auth.schema.js";

const router = Router()

router.post('/register', validateSchema(registerSchema), register)
router.post('/login', validateSchema(loginSchema), login)

export default router