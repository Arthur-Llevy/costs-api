import { fastify, FastifyInstance } from 'fastify';
import { serializerCompiler, validatorCompiler } from 'fastify-type-provider-zod';
import { prisma } from './lib/prisma'

const app: FastifyInstance = fastify();

app.setSerializerCompiler(serializerCompiler);
app.setValidatorCompiler(validatorCompiler);

app.get('/', async (r, re) => {
	const res = await prisma.projectService.findMany({
		project: {
			
		}
	})

	return re.send({res})
})

app.listen({
	port: 3333,
	host: '0.0.0.0'
})
	.then(() => console.log('Server on. Port: 3333'))