```bat
pnpm init
pnpm install prisma typescript ts-node @types/node --save-dev
pnpm dlx prisma
pnpm dlx prisma init
pnpm install @prisma/client

#Sigle Step Process
pnpm dlx prisma migrate dev --name init

#Two Step Process
pnpm dlx prisma migrate dev --create-only --name init
pnpm dlx prisma migrate deploy

#rollback
pnpm dlx prisam migrate resolve --rolled-back "20220819190846_questions"

#run
pnpm ts-node index.ts
```

```evn
DATABASE_URL="postgresql://postgres:33787bafa98847078fb363640ea87c6f@localhost:5432/prismatest?schema=public"
```

```sql
CREATE DATABASE prismatest
```

tsconfig.json

```json
{
  "compilerOptions": {
    "sourceMap": true,
    "outDir": "dist",
    "strict": true,
    "lib": ["esnext"],
    "esModuleInterop": true
  }
}
```

schema.prisma

```prisma
model Post {
  id        Int      @id @default(autoincrement())
  createdAt DateTime @default(now())
  updatedAt DateTime @updatedAt
  title     String   @db.VarChar(255)
  content   String?
  published Boolean  @default(false)
  author    User     @relation(fields: [authorId], references: [id])
  authorId  Int
}

model Profile {
  id     Int     @id @default(autoincrement())
  bio    String?
  user   User    @relation(fields: [userId], references: [id])
  userId Int     @unique
}

model User {
  id      Int      @id @default(autoincrement())
  email   String   @unique
  name    String?
  posts   Post[]
  profile Profile?
}
```
