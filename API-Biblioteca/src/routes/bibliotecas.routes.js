import {Router} from 'express'
import {validateSchema} from '../middlewares/validate.middleware.js'
import {bibliotecasSchema} from "../schemas/bibliotecas.schema.js";
import {addBiblioteca, getBibliotecas} from "../controllers/bibliotecas.controller.js"

const router = Router()

router.get('/bibliotecas', getBibliotecas)
router.post('/bibliotecas', validateSchema(bibliotecasSchema), addBiblioteca)

export default router