import { query } from "@/lib/db";
import type { Post, CreatePostInput } from "@/types/index";

export const PostModel = {
  //تمام فایل های منتشر شده
  async findAllPublished(): Promise<Post[]> {
    const res = await query(
      `SELECT * FROM posts WHERE published=true ORDER BY "createdAt" DESC`,
    );
    return res.rows as Post[];
  },

  async findBySlug(slug: string): Promise<Post[]> {
    const res = await query(
      `SELECT * FROM posts WHERE slug=$1 AND published=true`,
      [slug],
    );
    return res.rows as Post[];
  },

  async findById(id: number): Promise<Post[]> {
    const res = await query(`SELECT * FROM posts WHERE id=$1`, [id]);
    return res.rows as Post[];
  },

  async create(data: CreatePostInput): Promise<Post> {
    const res = await query(
      `INSERT INTO posts (title,slug,content,image,published) VALUES($1,$2,$3,$4,$5) RETURNING *`,
      [data.title, data.slug, data.content, data.image, data.published],
    );
    return res.rows[0] as Post;
  },

  // async update(
  //   id: number,
  //   data: Partial<CreatePostInput>,
  // ): Promise<Post | null> {
  //   const fields = [];
  //   const values = [];
  //   let i = 1;
  //   for (const [key, value] of Object.entries(data)) {
  //     if (value !== undefined) {
  //       fields.push(`${key},$${i}`);
  //       values.push(value);
  //       i++;
  //     }
  //   }
  //   if (fields.length === 0) return null;
  //   values.push(id);

  //   const res = await query(
  //     `UPDATE post SET ${fields.join(", ")},"updatedAt" = CURRENT_TIMESTAMP} WHERE id=$${i} RETURNING *`,
  //     values,
  //   );
  //   return (res.rows[0] as Post) || null;
  // },

  async update(
    id: number,
    data: Partial<CreatePostInput>,
  ): Promise<Post | null> {
    const { title, slug, content, published } = data;
    // استفاده از COALESCE: اگر مقدار undefined/null باشد، مقدار قبلی حفظ می‌شود
    const res = await query(
      `
    UPDATE posts 
     SET title = COALESCE($1, title),
         slug = COALESCE($2, slug),
         content = COALESCE($3, content),
         published = COALESCE($4, published),
         "updatedAt" = CURRENT_TIMESTAMP
     WHERE id = $5
     RETURNING *`,
      [
        title ?? null, //title === undefined ? null : title,
        slug ?? null,
        content ?? null,
        published ?? null,
        id,
      ],
    );
    return res.rows[0] as Post | null;
  },

  async delete(id: number): Promise<boolean> {
    const res = await query(`DELETE FROM posts WHERE id=$1 RETURNING id`, [id]);
    return res.rowCount !== null && res.rowCount > 0;
  },
};
