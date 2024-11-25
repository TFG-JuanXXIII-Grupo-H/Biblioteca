import {Router} from 'express'
import {validateSchema} from '../middlewares/validate.middleware.js'
import {sociosSchema} from "../schemas/socios.schema.js";
import {addSocios, getSocios} from "../controllers/socios.controller.js"

const router = Router()

router.get('/socios', getSocios)
router.post('/socios', validateSchema(sociosSchema), addSocios)

export default router