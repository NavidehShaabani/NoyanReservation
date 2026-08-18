## Payment Allocation

## problem

At first, I had two entities : `charge` and `Payment`.
but i realized that i couldn't manage payments and charges with these two entities.
for example:

- A user may pay part of a charge
- A user may pay several charges in one payment
- A user may pay another user's charge

## solution

So, I created a new entity called payment_allocation with the following fields:

- `payment_id`
- `charge_id`
- `amount`

  With this entity, I can specify :

- Witch charge and each payment is related to.
- How much is paid for each charge.
