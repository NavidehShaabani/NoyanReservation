    RESOURCE_ASSET_RULES {
         bigint id PK
         bigint resource_asset_id FK
         int booking_type_id FK
         boolean allow "true=asset can use in this type of booking , false=asset can't use in this type of booking"
         smallint paid_type "1=free, 2=optional_paid , 3=required_paid "
    }


    allow =false
    paid_type=2



    ==>

        RESOURCE_ASSET_RULES {
         bigint id PK
         bigint resource_asset_id FK
         int booking_type_id FK
         boolean allow "true=asset can use in this type of booking , false=asset can't use in this type of booking"
         smallint mode "1=unavailable, 2=free, 3=optional_paid , 4=required_paid "
    }

---

---

---

i should prepare db for i18n

---

---
