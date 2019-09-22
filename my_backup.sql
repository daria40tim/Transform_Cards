PGDMP     1                    w            transform_cards    9.6.15    9.6.15 9    �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                       false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                       false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                       false            �           1262    16393    transform_cards    DATABASE     �   CREATE DATABASE transform_cards WITH TEMPLATE = template0 ENCODING = 'UTF8' LC_COLLATE = 'Russian_Russia.1251' LC_CTYPE = 'Russian_Russia.1251';
    DROP DATABASE transform_cards;
             postgres    false                        2615    2200    public    SCHEMA        CREATE SCHEMA public;
    DROP SCHEMA public;
             postgres    false            �           0    0    SCHEMA public    COMMENT     6   COMMENT ON SCHEMA public IS 'standard public schema';
                  postgres    false    3                        3079    12387    plpgsql 	   EXTENSION     ?   CREATE EXTENSION IF NOT EXISTS plpgsql WITH SCHEMA pg_catalog;
    DROP EXTENSION plpgsql;
                  false            �           0    0    EXTENSION plpgsql    COMMENT     @   COMMENT ON EXTENSION plpgsql IS 'PL/pgSQL procedural language';
                       false    1            �            1259    16418    nomenclature    TABLE     �   CREATE TABLE public.nomenclature (
    id_nom integer NOT NULL,
    title character varying(50) NOT NULL,
    feature character varying(50),
    measure character varying(25)
);
     DROP TABLE public.nomenclature;
       public         postgres    false    3            �            1259    16416    nomenclature_id_nom_seq    SEQUENCE     �   CREATE SEQUENCE public.nomenclature_id_nom_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 .   DROP SEQUENCE public.nomenclature_id_nom_seq;
       public       postgres    false    188    3            �           0    0    nomenclature_id_nom_seq    SEQUENCE OWNED BY     S   ALTER SEQUENCE public.nomenclature_id_nom_seq OWNED BY public.nomenclature.id_nom;
            public       postgres    false    187            �            1259    16466    request    TABLE     �   CREATE TABLE public.request (
    req_id integer NOT NULL,
    req_date date,
    doc character varying(50),
    number character varying(50) NOT NULL
);
    DROP TABLE public.request;
       public         postgres    false    3            �            1259    16464    request_req_id_seq    SEQUENCE     {   CREATE SEQUENCE public.request_req_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 )   DROP SEQUENCE public.request_req_id_seq;
       public       postgres    false    3    194            �           0    0    request_req_id_seq    SEQUENCE OWNED BY     I   ALTER SEQUENCE public.request_req_id_seq OWNED BY public.request.req_id;
            public       postgres    false    193            �            1259    16407    tp_card    TABLE     )  CREATE TABLE public.tp_card (
    card_id integer NOT NULL,
    tr_type character varying(10) NOT NULL,
    tr_power double precision NOT NULL,
    pr_voltage character varying(50) NOT NULL,
    sec_voltage character varying(50) NOT NULL,
    is_shielded boolean,
    bd_date date,
    author integer,
    bid boolean,
    is_not_tested boolean,
    picture character varying(100),
    card_file character varying(100),
    addition character varying(100),
    conn_type character varying(25),
    coil_num integer,
    measure character varying(10)
);
    DROP TABLE public.tp_card;
       public         postgres    false    3            �            1259    16405    thp_card_th_card_id_seq    SEQUENCE     �   CREATE SEQUENCE public.thp_card_th_card_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 .   DROP SEQUENCE public.thp_card_th_card_id_seq;
       public       postgres    false    186    3            �           0    0    thp_card_th_card_id_seq    SEQUENCE OWNED BY     O   ALTER SEQUENCE public.thp_card_th_card_id_seq OWNED BY public.tp_card.card_id;
            public       postgres    false    185            �            1259    16485 	   tr_eq_ref    TABLE     �   CREATE TABLE public.tr_eq_ref (
    id_ref integer NOT NULL,
    id_card integer NOT NULL,
    id_req integer,
    value integer
);
    DROP TABLE public.tr_eq_ref;
       public         postgres    false    3            �            1259    16483    tr_eq_ref_id_ref_seq    SEQUENCE     }   CREATE SEQUENCE public.tr_eq_ref_id_ref_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 +   DROP SEQUENCE public.tr_eq_ref_id_ref_seq;
       public       postgres    false    196    3            �           0    0    tr_eq_ref_id_ref_seq    SEQUENCE OWNED BY     M   ALTER SEQUENCE public.tr_eq_ref_id_ref_seq OWNED BY public.tr_eq_ref.id_ref;
            public       postgres    false    195            �            1259    16429 
   tr_nom_ref    TABLE     �   CREATE TABLE public.tr_nom_ref (
    id_ref integer NOT NULL,
    id_card integer NOT NULL,
    id_nom integer NOT NULL,
    count integer
);
    DROP TABLE public.tr_nom_ref;
       public         postgres    false    3            �            1259    16427    tr_nom_ref_id_ref_seq    SEQUENCE     ~   CREATE SEQUENCE public.tr_nom_ref_id_ref_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 ,   DROP SEQUENCE public.tr_nom_ref_id_ref_seq;
       public       postgres    false    190    3            �           0    0    tr_nom_ref_id_ref_seq    SEQUENCE OWNED BY     O   ALTER SEQUENCE public.tr_nom_ref_id_ref_seq OWNED BY public.tr_nom_ref.id_ref;
            public       postgres    false    189            �            1259    16450    worker    TABLE     �   CREATE TABLE public.worker (
    worker_id integer NOT NULL,
    name character varying(50) NOT NULL,
    login character varying(25),
    password character varying(25),
    job character varying(50)
);
    DROP TABLE public.worker;
       public         postgres    false    3            �            1259    16448    worker_worker_id_seq    SEQUENCE     }   CREATE SEQUENCE public.worker_worker_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 +   DROP SEQUENCE public.worker_worker_id_seq;
       public       postgres    false    192    3            �           0    0    worker_worker_id_seq    SEQUENCE OWNED BY     M   ALTER SEQUENCE public.worker_worker_id_seq OWNED BY public.worker.worker_id;
            public       postgres    false    191            �           2604    16421    nomenclature id_nom    DEFAULT     z   ALTER TABLE ONLY public.nomenclature ALTER COLUMN id_nom SET DEFAULT nextval('public.nomenclature_id_nom_seq'::regclass);
 B   ALTER TABLE public.nomenclature ALTER COLUMN id_nom DROP DEFAULT;
       public       postgres    false    187    188    188            �           2604    16469    request req_id    DEFAULT     p   ALTER TABLE ONLY public.request ALTER COLUMN req_id SET DEFAULT nextval('public.request_req_id_seq'::regclass);
 =   ALTER TABLE public.request ALTER COLUMN req_id DROP DEFAULT;
       public       postgres    false    194    193    194            �           2604    16410    tp_card card_id    DEFAULT     v   ALTER TABLE ONLY public.tp_card ALTER COLUMN card_id SET DEFAULT nextval('public.thp_card_th_card_id_seq'::regclass);
 >   ALTER TABLE public.tp_card ALTER COLUMN card_id DROP DEFAULT;
       public       postgres    false    185    186    186            �           2604    16488    tr_eq_ref id_ref    DEFAULT     t   ALTER TABLE ONLY public.tr_eq_ref ALTER COLUMN id_ref SET DEFAULT nextval('public.tr_eq_ref_id_ref_seq'::regclass);
 ?   ALTER TABLE public.tr_eq_ref ALTER COLUMN id_ref DROP DEFAULT;
       public       postgres    false    196    195    196            �           2604    16432    tr_nom_ref id_ref    DEFAULT     v   ALTER TABLE ONLY public.tr_nom_ref ALTER COLUMN id_ref SET DEFAULT nextval('public.tr_nom_ref_id_ref_seq'::regclass);
 @   ALTER TABLE public.tr_nom_ref ALTER COLUMN id_ref DROP DEFAULT;
       public       postgres    false    189    190    190            �           2604    16453    worker worker_id    DEFAULT     t   ALTER TABLE ONLY public.worker ALTER COLUMN worker_id SET DEFAULT nextval('public.worker_worker_id_seq'::regclass);
 ?   ALTER TABLE public.worker ALTER COLUMN worker_id DROP DEFAULT;
       public       postgres    false    191    192    192            �          0    16418    nomenclature 
   TABLE DATA               G   COPY public.nomenclature (id_nom, title, feature, measure) FROM stdin;
    public       postgres    false    188   �?       �           0    0    nomenclature_id_nom_seq    SEQUENCE SET     F   SELECT pg_catalog.setval('public.nomenclature_id_nom_seq', 10, true);
            public       postgres    false    187            �          0    16466    request 
   TABLE DATA               @   COPY public.request (req_id, req_date, doc, number) FROM stdin;
    public       postgres    false    194   �@       �           0    0    request_req_id_seq    SEQUENCE SET     A   SELECT pg_catalog.setval('public.request_req_id_seq', 1, false);
            public       postgres    false    193            �           0    0    thp_card_th_card_id_seq    SEQUENCE SET     E   SELECT pg_catalog.setval('public.thp_card_th_card_id_seq', 6, true);
            public       postgres    false    185            �          0    16407    tp_card 
   TABLE DATA               �   COPY public.tp_card (card_id, tr_type, tr_power, pr_voltage, sec_voltage, is_shielded, bd_date, author, bid, is_not_tested, picture, card_file, addition, conn_type, coil_num, measure) FROM stdin;
    public       postgres    false    186   �@       �          0    16485 	   tr_eq_ref 
   TABLE DATA               C   COPY public.tr_eq_ref (id_ref, id_card, id_req, value) FROM stdin;
    public       postgres    false    196   �A       �           0    0    tr_eq_ref_id_ref_seq    SEQUENCE SET     C   SELECT pg_catalog.setval('public.tr_eq_ref_id_ref_seq', 1, false);
            public       postgres    false    195            �          0    16429 
   tr_nom_ref 
   TABLE DATA               D   COPY public.tr_nom_ref (id_ref, id_card, id_nom, count) FROM stdin;
    public       postgres    false    190   B       �           0    0    tr_nom_ref_id_ref_seq    SEQUENCE SET     D   SELECT pg_catalog.setval('public.tr_nom_ref_id_ref_seq', 12, true);
            public       postgres    false    189            �          0    16450    worker 
   TABLE DATA               G   COPY public.worker (worker_id, name, login, password, job) FROM stdin;
    public       postgres    false    192   _B       �           0    0    worker_worker_id_seq    SEQUENCE SET     B   SELECT pg_catalog.setval('public.worker_worker_id_seq', 1, true);
            public       postgres    false    191            �           2606    16426    nomenclature nomenclature_pkey 
   CONSTRAINT     `   ALTER TABLE ONLY public.nomenclature
    ADD CONSTRAINT nomenclature_pkey PRIMARY KEY (id_nom);
 H   ALTER TABLE ONLY public.nomenclature DROP CONSTRAINT nomenclature_pkey;
       public         postgres    false    188    188                        2606    16595    request request_number_key 
   CONSTRAINT     W   ALTER TABLE ONLY public.request
    ADD CONSTRAINT request_number_key UNIQUE (number);
 D   ALTER TABLE ONLY public.request DROP CONSTRAINT request_number_key;
       public         postgres    false    194    194                       2606    16474    request request_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY public.request
    ADD CONSTRAINT request_pkey PRIMARY KEY (req_id);
 >   ALTER TABLE ONLY public.request DROP CONSTRAINT request_pkey;
       public         postgres    false    194    194            �           2606    16415    tp_card thp_card_pkey 
   CONSTRAINT     X   ALTER TABLE ONLY public.tp_card
    ADD CONSTRAINT thp_card_pkey PRIMARY KEY (card_id);
 ?   ALTER TABLE ONLY public.tp_card DROP CONSTRAINT thp_card_pkey;
       public         postgres    false    186    186                       2606    16490    tr_eq_ref tr_eq_ref_pkey 
   CONSTRAINT     Z   ALTER TABLE ONLY public.tr_eq_ref
    ADD CONSTRAINT tr_eq_ref_pkey PRIMARY KEY (id_ref);
 B   ALTER TABLE ONLY public.tr_eq_ref DROP CONSTRAINT tr_eq_ref_pkey;
       public         postgres    false    196    196            �           2606    16437    tr_nom_ref tr_nom_ref_pkey 
   CONSTRAINT     \   ALTER TABLE ONLY public.tr_nom_ref
    ADD CONSTRAINT tr_nom_ref_pkey PRIMARY KEY (id_ref);
 D   ALTER TABLE ONLY public.tr_nom_ref DROP CONSTRAINT tr_nom_ref_pkey;
       public         postgres    false    190    190            �           2606    16621    worker worker_login_key 
   CONSTRAINT     S   ALTER TABLE ONLY public.worker
    ADD CONSTRAINT worker_login_key UNIQUE (login);
 A   ALTER TABLE ONLY public.worker DROP CONSTRAINT worker_login_key;
       public         postgres    false    192    192            �           2606    16458    worker worker_pkey 
   CONSTRAINT     W   ALTER TABLE ONLY public.worker
    ADD CONSTRAINT worker_pkey PRIMARY KEY (worker_id);
 <   ALTER TABLE ONLY public.worker DROP CONSTRAINT worker_pkey;
       public         postgres    false    192    192                       2606    16438    tr_nom_ref card_fk    FK CONSTRAINT     �   ALTER TABLE ONLY public.tr_nom_ref
    ADD CONSTRAINT card_fk FOREIGN KEY (id_card) REFERENCES public.tp_card(card_id) ON UPDATE CASCADE ON DELETE CASCADE;
 <   ALTER TABLE ONLY public.tr_nom_ref DROP CONSTRAINT card_fk;
       public       postgres    false    2038    186    190                       2606    16443    tr_nom_ref nom_fk    FK CONSTRAINT     �   ALTER TABLE ONLY public.tr_nom_ref
    ADD CONSTRAINT nom_fk FOREIGN KEY (id_nom) REFERENCES public.nomenclature(id_nom) ON UPDATE CASCADE ON DELETE SET DEFAULT;
 ;   ALTER TABLE ONLY public.tr_nom_ref DROP CONSTRAINT nom_fk;
       public       postgres    false    2040    188    190                       2606    16491     tr_eq_ref tr_eq_ref_id_card_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.tr_eq_ref
    ADD CONSTRAINT tr_eq_ref_id_card_fkey FOREIGN KEY (id_card) REFERENCES public.tp_card(card_id);
 J   ALTER TABLE ONLY public.tr_eq_ref DROP CONSTRAINT tr_eq_ref_id_card_fkey;
       public       postgres    false    196    186    2038            	           2606    16496    tr_eq_ref tr_eq_ref_id_req_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.tr_eq_ref
    ADD CONSTRAINT tr_eq_ref_id_req_fkey FOREIGN KEY (id_req) REFERENCES public.request(req_id);
 I   ALTER TABLE ONLY public.tr_eq_ref DROP CONSTRAINT tr_eq_ref_id_req_fkey;
       public       postgres    false    2050    194    196                       2606    16459    tp_card w_fk    FK CONSTRAINT     �   ALTER TABLE ONLY public.tp_card
    ADD CONSTRAINT w_fk FOREIGN KEY (author) REFERENCES public.worker(worker_id) ON UPDATE CASCADE;
 6   ALTER TABLE ONLY public.tp_card DROP CONSTRAINT w_fk;
       public       postgres    false    192    186    2046            �   �   x�}��j1F�7O�ua�I�G}_Fa�E�7R�\uS����<�w���NJJ�"�pr/xE���-k�w8��}�?������茠��8� xCC��y�%�#Zqn"��yj���Pc��"j���6��-/nx$��Z�.
g`�JO	����(/���z�Y��t6�J����H�f�t{��A�T">�񞸌�M�PZXG�_�:��Q��Ƙ+c��      �      x������ � �      �     x�m�MN�0FדS� �df�CO�t*;`�@7�ذFH�������&7b�ĥ�%Nb�����w��7����b�K$�O�!NH=���}���eιR���_�W�փ���5�[#҄�H%��<QpS)�B(����������s=[�K�&�pBN��?M��D��%�1���upA?��|D���)c�te�2g��Q�k��\��~��˟��2���&���5L ���Y���f͡�OO��s��'���G��B��i�?�ʡ�      �      x������ � �      �   L   x��� 1B�a�K�ֶ���s^L�AD! ���	�wZ�uA,���vn��px���A$%�������!��{�      �   P   x�3�0����.6\�waӅ
�]��Ǚ��_�_��ihdl�yaƅ��]�
$�^lн��Z��}v�f�=... �(�     