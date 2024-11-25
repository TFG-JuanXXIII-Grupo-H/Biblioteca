export const validateSchema = (schema) => (req, res, next) => {
    try {
        schema.parse(req.body);
        next();
    } catch (error) {
        if (error.errors) {
            const errors = error.errors.map(err => ({
                code: err.code,
                message: err.message,
                path: err.path
            }));
            return res.status(400).json({errors: errors});
        }
    }
}
