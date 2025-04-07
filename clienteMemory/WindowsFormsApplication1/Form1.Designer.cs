namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.connectButton = new System.Windows.Forms.Button();
            this.selectButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.partida = new System.Windows.Forms.TextBox();
            this.privadaButton = new System.Windows.Forms.RadioButton();
            this.equiposButton = new System.Windows.Forms.RadioButton();
            this.individualButton = new System.Windows.Forms.RadioButton();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.IPBox = new System.Windows.Forms.TextBox();
            this.PortBox = new System.Windows.Forms.TextBox();
            this.registerButton = new System.Windows.Forms.Button();
            this.loginButton = new System.Windows.Forms.Button();
            this.UserBox = new System.Windows.Forms.TextBox();
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ModificarButton = new System.Windows.Forms.Button();
            this.edad = new System.Windows.Forms.TextBox();
            this.nombre = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 31);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(333, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Selecciona tipo de partida:";
            // 
            // connectButton
            // 
            this.connectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.connectButton.Location = new System.Drawing.Point(31, 79);
            this.connectButton.Margin = new System.Windows.Forms.Padding(4);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(125, 32);
            this.connectButton.TabIndex = 4;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // selectButton
            // 
            this.selectButton.Location = new System.Drawing.Point(182, 145);
            this.selectButton.Margin = new System.Windows.Forms.Padding(4);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(100, 28);
            this.selectButton.TabIndex = 5;
            this.selectButton.Text = "Seleccionar";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox1.Controls.Add(this.partida);
            this.groupBox1.Controls.Add(this.privadaButton);
            this.groupBox1.Controls.Add(this.equiposButton);
            this.groupBox1.Controls.Add(this.individualButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.selectButton);
            this.groupBox1.Location = new System.Drawing.Point(31, 474);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(484, 205);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Partidas";
            // 
            // partida
            // 
            this.partida.Location = new System.Drawing.Point(264, 94);
            this.partida.Margin = new System.Windows.Forms.Padding(4);
            this.partida.Name = "partida";
            this.partida.Size = new System.Drawing.Size(125, 22);
            this.partida.TabIndex = 22;
            this.partida.Text = "Id partida";
            // 
            // privadaButton
            // 
            this.privadaButton.AutoSize = true;
            this.privadaButton.Location = new System.Drawing.Point(249, 66);
            this.privadaButton.Margin = new System.Windows.Forms.Padding(4);
            this.privadaButton.Name = "privadaButton";
            this.privadaButton.Size = new System.Drawing.Size(81, 20);
            this.privadaButton.TabIndex = 9;
            this.privadaButton.TabStop = true;
            this.privadaButton.Text = "Privada :";
            this.privadaButton.UseVisualStyleBackColor = true;
            this.privadaButton.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // equiposButton
            // 
            this.equiposButton.AutoSize = true;
            this.equiposButton.Location = new System.Drawing.Point(14, 94);
            this.equiposButton.Margin = new System.Windows.Forms.Padding(4);
            this.equiposButton.Name = "equiposButton";
            this.equiposButton.Size = new System.Drawing.Size(101, 20);
            this.equiposButton.TabIndex = 7;
            this.equiposButton.TabStop = true;
            this.equiposButton.Text = "Por equipos";
            this.equiposButton.UseVisualStyleBackColor = true;
            // 
            // individualButton
            // 
            this.individualButton.AutoSize = true;
            this.individualButton.Location = new System.Drawing.Point(14, 66);
            this.individualButton.Margin = new System.Windows.Forms.Padding(4);
            this.individualButton.Name = "individualButton";
            this.individualButton.Size = new System.Drawing.Size(85, 20);
            this.individualButton.TabIndex = 8;
            this.individualButton.TabStop = true;
            this.individualButton.Text = "Individual";
            this.individualButton.UseVisualStyleBackColor = true;
            // 
            // disconnectButton
            // 
            this.disconnectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.disconnectButton.Location = new System.Drawing.Point(173, 79);
            this.disconnectButton.Margin = new System.Windows.Forms.Padding(4);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(125, 32);
            this.disconnectButton.TabIndex = 10;
            this.disconnectButton.Text = "Disconnect";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // IPBox
            // 
            this.IPBox.Location = new System.Drawing.Point(31, 49);
            this.IPBox.Margin = new System.Windows.Forms.Padding(4);
            this.IPBox.Name = "IPBox";
            this.IPBox.Size = new System.Drawing.Size(125, 22);
            this.IPBox.TabIndex = 11;
            this.IPBox.Text = "IP Address";
            // 
            // PortBox
            // 
            this.PortBox.Location = new System.Drawing.Point(173, 49);
            this.PortBox.Margin = new System.Windows.Forms.Padding(4);
            this.PortBox.Name = "PortBox";
            this.PortBox.Size = new System.Drawing.Size(125, 22);
            this.PortBox.TabIndex = 12;
            this.PortBox.Text = "Port";
            // 
            // registerButton
            // 
            this.registerButton.Location = new System.Drawing.Point(173, 197);
            this.registerButton.Margin = new System.Windows.Forms.Padding(4);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(125, 28);
            this.registerButton.TabIndex = 18;
            this.registerButton.Text = "Register";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(31, 197);
            this.loginButton.Margin = new System.Windows.Forms.Padding(4);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(125, 28);
            this.loginButton.TabIndex = 17;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // UserBox
            // 
            this.UserBox.Location = new System.Drawing.Point(31, 167);
            this.UserBox.Margin = new System.Windows.Forms.Padding(4);
            this.UserBox.Name = "UserBox";
            this.UserBox.Size = new System.Drawing.Size(125, 22);
            this.UserBox.TabIndex = 19;
            this.UserBox.Text = "Username";
            // 
            // PasswordBox
            // 
            this.PasswordBox.Location = new System.Drawing.Point(173, 167);
            this.PasswordBox.Margin = new System.Windows.Forms.Padding(4);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.Size = new System.Drawing.Size(125, 22);
            this.PasswordBox.TabIndex = 20;
            this.PasswordBox.Text = "Password";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(31, 350);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 28);
            this.button1.TabIndex = 21;
            this.button1.Text = "Mejor Tiempo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // ModificarButton
            // 
            this.ModificarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.ModificarButton.Location = new System.Drawing.Point(517, 79);
            this.ModificarButton.Margin = new System.Windows.Forms.Padding(4);
            this.ModificarButton.Name = "ModificarButton";
            this.ModificarButton.Size = new System.Drawing.Size(125, 32);
            this.ModificarButton.TabIndex = 22;
            this.ModificarButton.Text = "Modificar perfil";
            this.ModificarButton.UseVisualStyleBackColor = true;
            this.ModificarButton.Click += new System.EventHandler(this.ModificarButton_Click);
            // 
            // edad
            // 
            this.edad.Location = new System.Drawing.Point(563, 49);
            this.edad.Margin = new System.Windows.Forms.Padding(4);
            this.edad.Name = "edad";
            this.edad.Size = new System.Drawing.Size(125, 22);
            this.edad.TabIndex = 23;
            this.edad.Text = "Edad";
            // 
            // nombre
            // 
            this.nombre.Location = new System.Drawing.Point(421, 49);
            this.nombre.Margin = new System.Windows.Forms.Padding(4);
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(125, 22);
            this.nombre.TabIndex = 24;
            this.nombre.Text = "Nombre";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 692);
            this.Controls.Add(this.nombre);
            this.Controls.Add(this.edad);
            this.Controls.Add(this.ModificarButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PasswordBox);
            this.Controls.Add(this.UserBox);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.PortBox);
            this.Controls.Add(this.IPBox);
            this.Controls.Add(this.disconnectButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.connectButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton equiposButton;
        private System.Windows.Forms.RadioButton individualButton;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.TextBox IPBox;
        private System.Windows.Forms.TextBox PortBox;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.TextBox UserBox;
        private System.Windows.Forms.TextBox PasswordBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox partida;
        private System.Windows.Forms.RadioButton privadaButton;
        private System.Windows.Forms.Button ModificarButton;
        private System.Windows.Forms.TextBox edad;
        private System.Windows.Forms.TextBox nombre;
    }
}

